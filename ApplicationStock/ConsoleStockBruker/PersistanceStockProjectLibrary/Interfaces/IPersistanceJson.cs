using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceStockProjectLibrary
{
    public interface IPersistanceJson 
    {
        public string readJson(Type objectType, object existingValue);

        public void writeJson(Type objectType, object existingValue);

        public void updateJson(Type objectType, object existingValue);


    }
}
