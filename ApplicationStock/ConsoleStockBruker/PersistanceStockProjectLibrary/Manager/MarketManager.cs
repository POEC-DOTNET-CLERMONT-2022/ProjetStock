using System;
using System.Collections.Generic;
using System.Text;
using ProjectStockDTOS;
using AutoFixture;
using ProjectStockLibrary;
using PersistanceStockProjectLibrary.Interfaces;

namespace PersistanceStockProjectLibrary.Manager
{
    public class MarketManager : IMarketManager
    {
        private readonly Fixture _fixture = new Fixture();
        private List<MarketDto> markets { get; set; } = new List<MarketDto>();
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarketDto> GetMarkets()
        {
            var creatures = new List<Market>() { new Market("mon_market") };

            foreach (var creature in creatures)
            {

                yield return new MarketDto() { _id = creature._id,_name = creature._name,_openingDate= creature._openingDate,_closingDate =creature._closingDate , _stocks = creature._stock};
            }
        }
        public IEnumerable<Market> GetAllMarkets()
        {
            var creatures = new List<Market>() { new Market("mon_market")  };
            return creatures;

        }

        public MarketDto GetById(int id)
        {
            return markets[id];
        }


        public void Update(int id, MarketDto marketDto)
        {

            try
            {
                markets[id] = marketDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur update " + ex.ToString());
            }

        }


        public void Add(MarketDto marketDto)
        {

            try
            {
                markets.Add(marketDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }

        }


        public void Delete(MarketDto marketDto)
        {
            try
            {
                markets.Remove(marketDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}
