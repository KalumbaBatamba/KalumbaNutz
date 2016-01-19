using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    abstract public class DbController
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

    }
}
