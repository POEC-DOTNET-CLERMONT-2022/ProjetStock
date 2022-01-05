using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoFixture;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary
{
    public class StockManager : IStockManager
    {
        private readonly Fixture _fixture = new Fixture();
        private List<StockDto> stocks { get; set; } = new List<StockDto>();
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockDto> GetStocks()
            {
                var creatures = new List<Stock>() { new Stock() {_name = "test", _value = 1F, _entrepriseName = "michelin" } };
           
               foreach (var creature in creatures)
                {

                    yield return new StockDto() { _id = creature._id, _name = creature._name, _entrepriseName =creature._entrepriseName, _value = creature._value };
                }
            }
        public IEnumerable<Stock> GetAllStocks()
        {
            var creatures = new List<Stock>() { new Stock() { _name = "test", _value = 1F, _entrepriseName = "michelin" } };
            return creatures;

        }

        public StockDto GetById(int id)
        {
            return stocks[id];
        }


        public void Update(int id, StockDto stockDto)
        {

            try
            {
                stocks[id] = stockDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur update " + ex.ToString());
            }

        }


        public void Add(StockDto stockDto)
        {

            try
            {
                stocks.Add(stockDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }

        }


        public void Delete(StockDto stockDto)
        {
            try
            {
                stocks.Remove(stockDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}