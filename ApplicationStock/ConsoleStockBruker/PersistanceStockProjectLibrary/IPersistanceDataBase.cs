using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceStockProjectLibrary
{
    internal interface IPersistanceDataBase 
    {
        public void persistInDatabase();

        public void deleteItemOnDatabase();

        public void updateItemOnDatabase();

        public void findItemOnDatabase(int i);  // prefer  object

        public void findItemsOnDatabase();

    }
}
