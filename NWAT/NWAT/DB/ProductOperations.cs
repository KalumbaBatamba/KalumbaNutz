using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    class ProductOperations
    {
        /// <summary>
        /// Gets the product by identifier from db.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An instance of 'Product'
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public static Product GetProductById(int id)
        {
            Product resultProduct;

            using (NWATDataContext dataContext = new NWATDataContext())
            {
                resultProduct = dataContext.Product.SingleOrDefault(product => product.Product_Id == id);
            }
            return resultProduct;
        }
        
        /// <summary>
        /// Gets all products from database.
        /// </summary>
        /// <returns>
        /// A linq table object with all products from db
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public static List<Product> GetAllProductsFromDb()
        {
            List<Product> products;
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                products = dataContext.Product.ToList();
            }
            return products;
        }

        /// <summary>
        /// Inserts the product into database.
        /// </summary>
        /// <param name="newProduct">The new product.</param>
        /// <returns>
        /// bool if insert of new product was successfull.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        ///  Das Produkt mit dem Namen -Produktname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Produkt konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Produkt Objekt.
        /// </exception>
        public static bool InsertProductIntoDb(Product newProduct)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                if (newProduct != null)
                {
                    string newProductName = newProduct.Name;
                    if (!checkIfProductNameAlreadyExists(newProductName))
                    {
                        dataContext.Product.InsertOnSubmit(newProduct);
                        dataContext.SubmitChanges();
                    }
                    else
                    {
                        throw (new DatabaseException((MessageProductAlreadyExists(newProductName))));
                    }
                }
                else
                {
                    throw (new DatabaseException(MessageProductCouldNotBeSavedEmptyObject()));        
                }

                Product newProductFromDb = (from prod in dataContext.Product
                                                where prod.Name == newProduct.Name 
                                                && prod.Producer == newProduct.Producer
                                                && prod.Price == newProduct.Price 
                                                select prod).FirstOrDefault();

                return checkIfEqualProducts(newProduct, newProductFromDb);   
            }
            
        }


        /// <summary>
        /// Updates the product in database.
        /// </summary>
        /// <param name="alteredProduct">The altered product.</param>
        /// <returns>
        /// bool if update of product was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        /// Das Produkt mit dem Namen -Produktname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Produkt konnte nicht in der Datenbank gespeichert werden. 
        /// Bitte überprüfen Sie das übergebene Produkt Objekt.
        /// or 
        /// Das Product Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object
        /// </exception>
        public static bool UpdateProductInDb(Product alteredProduct)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {

                if(!CheckIfProductHasAnId(alteredProduct))
                    throw (new DatabaseException(MessageProductHasNoId()));

                int productId = alteredProduct.Product_Id;
                Product prodToUpdateFromDb = dataContext.Product.SingleOrDefault(prod=>prod.Product_Id==productId);

                if (prodToUpdateFromDb != null)
                {
                    string newProductName = alteredProduct.Name;
                    if (!checkIfProductNameAlreadyExists(newProductName, productId))
                    {
                        prodToUpdateFromDb.Name = alteredProduct.Name;
                        prodToUpdateFromDb.Producer = alteredProduct.Producer;
                        prodToUpdateFromDb.Price = alteredProduct.Price;
                    }
                    else
                    {
                        throw (new DatabaseException(MessageProductAlreadyExists(newProductName)));
                    }
                }
                else
                {
                    throw (new DatabaseException(MessageProductDoesNotExist(productId) + "\n" + 
                                                 MessageProductCouldNotBeSavedEmptyObject()));  
                }
                dataContext.SubmitChanges();
              
                Product alteredProductFromDb = GetProductById(productId);
                return checkIfEqualProducts(alteredProduct, alteredProductFromDb);
            }
        }


        /// <summary>
        /// Deletes the product from database.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// bool if deletion was successfull<
        /// /returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        /// "Das Produkt mit der Id X existiert nicht in der Datenbank."
        /// </exception>
        public static bool DeleteProductFromDb(int productId)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                Product delProduct = (from prod in dataContext.Product
                                          where prod.Product_Id == productId
                                          select prod).FirstOrDefault();
                if (delProduct != null)
                {
                    dataContext.Product.DeleteOnSubmit(delProduct);
                    dataContext.SubmitChanges();
                }
                else
                {
                    throw(new DatabaseException(MessageProductDoesNotExist(productId)));
                }

                return GetProductById(productId) == null;
            }
        }

        /*
         * Private Section
         */

        /// <summary>
        /// Checks if equal products.
        /// </summary>
        /// <param name="prodOne">The prod one.</param>
        /// <param name="prodTwo">The prod two.</param>
        /// <returns>
        /// bool if given products have equal properties
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private static bool checkIfEqualProducts(Product prodOne, Product prodTwo)
        {
            bool equalName = prodOne.Name == prodTwo.Name;
            bool equalProducer = prodOne.Producer == prodTwo.Producer;
            bool equalPrice = prodOne.Price == prodTwo.Price;

            return equalName && equalProducer && equalPrice;
        }

        /// <summary>
        /// Checks if product name already exists.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns>
        /// bool if product name already exists in db.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private static bool checkIfProductNameAlreadyExists(String productName)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                Product productWithExistingName = (from prod in dataContext.Product
                                                       where prod.Name == productName
                                                       select prod).FirstOrDefault();
                if (productWithExistingName != null)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Checks if product has an identifier.
        /// </summary>
        /// <param name="prod">The product.</param>
        /// <returns>
        /// bool if given product has an id and if it differs zero
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.12.2015
        private static bool CheckIfProductHasAnId(Product prod)
        {
            if (prod.Product_Id == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Checks if product name already exists.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="excludedId">The excluded identifier, which identifies the product, that should be updated.</param>
        /// <returns>
        /// bool if other product exist with name to which user want to update given product to.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private static bool checkIfProductNameAlreadyExists(String productName, int excludedId)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                Product productWithExistingName = (from prod in dataContext.Product
                                                       where prod.Name == productName 
                                                       && prod.Product_Id != excludedId
                                                       select prod).FirstOrDefault();
                if (productWithExistingName != null)
                    return true;
                else
                    return false;
            }
        }


        /*
         Messages
         */

        private static string MessageProductCouldNotBeSavedEmptyObject()
        {
            return "Das Produkt konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Produkt Objekt.";
        }

        private static string MessageProductAlreadyExists(string productName)
        {
            return "Das Produkt mit dem Namen \"" + productName +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private static string MessageProductDoesNotExist(int productId)
        {
            return "Das Produkt mit der Id \"" + productId +
                   "\" existiert nicht in der Datenbank.";
        }

        private static string MessageProductHasNoId()
        {
            return "Das Product Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object";
        }
    }
}
