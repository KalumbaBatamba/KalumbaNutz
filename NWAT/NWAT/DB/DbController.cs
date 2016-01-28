using System;

namespace NWAT.DB
{
    abstract public class DbController: IDisposable
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

        public DbController()
        {
            this._dataContext = new NWATDataContext();
        }

        public DbController(NWATDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Dispose() { }

    }
}
