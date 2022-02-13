using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockLibrary
{
    public  class Order : BaseEntity
    {
        
        public string _orderName { get;  set; }
        public  DateTime _orderDate { get;  set; }
       
     
        public Stock? _stock { get; set; }
        public Guid ClientId { get; set; }
        public int _nbStock { get; set; }
        public Order(string orderName,Stock stock,int nbStock) 
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            Id = Guid.NewGuid();
            _stock = stock;
            _nbStock = nbStock;

        }

        public Order()
        {
            _orderName = "test";
            _orderDate = DateTime.Now;
            Id = Guid.NewGuid();
            _stock = new Stock();
            _nbStock = 5;
        }
        public Order(string orderName, int nbStock)
        {
            _orderName = orderName;
            _orderDate = DateTime.Now;
            Id = Guid.NewGuid();
            _stock = new Stock();
            _nbStock = nbStock;
        }
        public Order(string orderName,Stock stock, int nbStock, DateTime orderDate, Guid id ) : this(orderName, stock, nbStock)
        {
            _orderName = string.IsNullOrEmpty(orderName) ? throw new ArgumentNullException(nameof(orderName)) : orderName;

        }
        public Order(string orderName, Stock stock, int nbStock, DateTime orderDate) : this(orderName, stock, nbStock)
        {
            Id = Guid.NewGuid();
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
                throw new ArgumentException("The stock is not Defined");
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
                throw new ArgumentException("The Stock Does not correspond to the Chosen One! Please Check!");
            }

        }
    }
    
}
