using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public  class Order
    {
        public Guid _id { get; private set; }
        public string _orderName { get; private set; }
        public  DateTime _orderDate { get; private set; }
        private Stock _stock { get; set; }
        public  int _nbStock { get; private set; }
        public Order(string orderName,Stock stock,int nbStock) 
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            _id = Guid.NewGuid();
            _stock = stock;
            _nbStock = nbStock;

        }

        public Order(string orderName, int nbStock)
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            _id = Guid.NewGuid();
            _stock = new Stock();
            _nbStock = nbStock;
        }
        public Order(string orderName,Stock stock, int nbStock, DateTime orderDate, Guid id ) : this(orderName, stock, nbStock)
        {
            _orderName = string.IsNullOrEmpty(orderName) ? throw new ArgumentNullException(nameof(orderName)) : orderName;
        }
        public void AddStocks(Stock stock)
        {
            if (!(stock is null))
            {
                _stock = stock;
              
            }
            else
            {
                throw new Exception("The stock is not Defined");
            }

        }

        public void modifyStock(Stock stock,string newNameStock, string newNameEnterprise, int newnbStock)
        {
            if (_stock == stock)
            {
                _stock._name = newNameStock;
                _stock._entrepriseName = newNameEnterprise;
                this._nbStock = newnbStock;

            }
            else
            {
                throw new Exception("The Stock Does not correspond to the Chosen One! Please Check!");
            }

        }
    }
    
}
