using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace WCFService_App.Ddos
{
    public class StocksManager
    {
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetCreatures()
        {
            return new List<Stock>() { new Stock { Id = System.Guid.NewGuid() } };
        }
    }
}