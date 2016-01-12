using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT
{
    class CommonMessages
    {
        public static string MessageInsertionToFulFillmentTableFailed(int prodId, int projCritId)
        {
            return String.Format(@"Der Eintrag für das Produkt mit der ID {0} und das Kriterium mit der ID {1} 
                                    konnte nicht in die Erfüllungstabelle eingefügt werden.", prodId, projCritId);
        }
    }
}
