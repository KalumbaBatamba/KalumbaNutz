using System.Linq;

namespace NWAT.DB
{
    public class CurrentMasterDataIdsController : DbController
    {
        public CurrentMasterDataIdsController() : base() { }
        public CurrentMasterDataIdsController(NWATDataContext dataContext) : 
            base (dataContext) { }

        /// <summary>
        /// Gets the current master data ids.
        /// </summary>
        /// <returns>
        /// An instance of CurrentMasterDataIds
        /// </returns>
        /// Erstellt von Joshua Frey, am 11.01.2016
        public CurrentMasterDataIds GetCurrentMasterDataIds()
        {
            CurrentMasterDataIds result = base.DataContext.CurrentMasterDataIds.FirstOrDefault();
            if (checkIfIdsAlreadyInitialized(result))
            { return result; }
            else
            {
                initialzeCurrentMasterIds();
                return base.DataContext.CurrentMasterDataIds.First();
            }

        }

        /// <summary>
        /// Increments the current project identifier.
        /// </summary>
        /// Erstellt von Joshua Frey, am 11.01.2016
        public void incrementCurrentProjectId()
        {
            CurrentMasterDataIds currentMasterDataIds = GetCurrentMasterDataIds();
            currentMasterDataIds.CurrentProjectId += 1;
            bool success = updateCurrentMasterDataIds(currentMasterDataIds);
            if (!success)
            {
                throw new NWATException(MessageUpdateFailed());
            }
        }

        /// <summary>
        /// Increments the current criterion identifier.
        /// </summary>
        /// Erstellt von Joshua Frey, am 11.01.2016
        /// <exception cref="NWATException"></exception>
        public void incrementCurrentCriterionId()
        {
            CurrentMasterDataIds currentMasterDataIds = GetCurrentMasterDataIds();
            currentMasterDataIds.CurrentCriterionId += 1;
            bool success = updateCurrentMasterDataIds(currentMasterDataIds);
            if (!success)
            {
                throw new NWATException(MessageUpdateFailed());
            }
        }

        /// <summary>
        /// Increments the current product identifier.
        /// </summary>
        /// Erstellt von Joshua Frey, am 11.01.2016
        public void incrementCurrentProductId()
        {
            CurrentMasterDataIds currentMasterDataIds = GetCurrentMasterDataIds();
            currentMasterDataIds.CurrentProductId += 1;
            bool success = updateCurrentMasterDataIds(currentMasterDataIds);
            if (!success)
            {
                throw new NWATException(MessageUpdateFailed());
            }
        }

        /// <summary>
        /// Updates the current master data ids.
        /// </summary>
        /// <param name="alteredDataSet">The altered data set.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 11.01.2016
        private bool updateCurrentMasterDataIds(CurrentMasterDataIds alteredDataSet)
        {
            CurrentMasterDataIds resultDataSet = base.DataContext.CurrentMasterDataIds.Single(currIds => currIds.Id == alteredDataSet.Id);
            resultDataSet.CurrentProjectId = alteredDataSet.CurrentProjectId;
            resultDataSet.CurrentCriterionId = alteredDataSet.CurrentCriterionId;
            resultDataSet.CurrentProductId = alteredDataSet.CurrentProductId;

            base.DataContext.SubmitChanges();

            CurrentMasterDataIds checkDataset = GetCurrentMasterDataIds();
            bool sameProjId = checkDataset.CurrentProjectId == alteredDataSet.CurrentProjectId;
            bool sameCritId = checkDataset.CurrentCriterionId == alteredDataSet.CurrentCriterionId;
            bool sameProdId = checkDataset.CurrentProductId == alteredDataSet.CurrentProductId;
            return sameCritId && sameProdId && sameProjId;
        }

        /// <summary>
        /// Checks if ids already initialized.
        /// </summary>
        /// <param name="masterDataIds">The master data ids.</param>
        /// <returns>
        /// boolean if there are any Ids
        /// </returns>
        /// Erstellt von Joshua Frey, am 11.01.2016
        private bool checkIfIdsAlreadyInitialized(CurrentMasterDataIds masterDataIds)
        {
            if (masterDataIds != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Initialzes the current master ids, by inserting a new row to the table CurrenMasterDataIds with all values of Ids = 1
        /// </summary>
        /// Erstellt von Joshua Frey, am 11.01.2016
        private void initialzeCurrentMasterIds()
        {
            CurrentMasterDataIds newDataRow = new CurrentMasterDataIds { CurrentProjectId = 1, CurrentCriterionId = 1, CurrentProductId = 1 };
            base.DataContext.CurrentMasterDataIds.InsertOnSubmit(newDataRow);
            base.DataContext.SubmitChanges();
        }


        private string MessageUpdateFailed()
        {
            return "Das Inkrementieren einer Id ist fehlgeschlagen.";
        }

 
    }
}
