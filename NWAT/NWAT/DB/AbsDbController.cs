using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    abstract class AbsDbController<T>
    {
        private NWATDataContext _dataContext;

        public NWATDataContext DataContext
        {
            get
            {
                return this._dataContext;
            }
            set
            {
                this._dataContext = value;
            }
        }


        public AbsDbController()
        {
            this._dataContext = new NWATDataContext();
        }

        public AbsDbController(NWATDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        /// <summary>
        /// Gets all entities from table.
        /// </summary>
        /// <returns>
        /// An object of IEnumerable which contains all table entries
        /// </returns>
        /// Erstellt von Joshua Frey, am 23.12.2015
        public abstract IEnumerable<T> GetAllFromTable();

        /// <summary>
        /// Inserts the into database.
        /// </summary>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>
        /// bool if insert was successfull
        /// </returns>
        /// Erstellt von Joshua Frey, am 23.12.2015
        public abstract bool InsertIntoDb(T newEntity);

        public abstract bool DeleteFromDb(T entityToDelete);

    }


}
