using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public class CommandeManager
    {
        public IWriterCommande _Writer { get; set; }
        public IReaderCommande _Reader { get; set; }

        private IList<Order> _items { get; set; }

        public CommandeManager(IWriterCommande writer, IReaderCommande reader)
        {
            _Writer = writer;
            _Reader = reader;
            _Reader.Writer = writer;
            _items = new List<Order>();
        }



        public void Create(Stock stock)
        {
            try
            {
                _items.Add(_Reader.create(stock));


            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
            }
        }


        public void update(int i, Order order)
        {
            try
            {
                _items[i] = order;
                /* _items*/
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un problème est survenue : {ex.Message}");
            }


        }
        public void delete(Order item)
        {
            try
            {
                _items.Remove(item);
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un problème est survenue : {ex.Message}");
            }

        }
        public void read()
        {
            try
            {
                foreach (var item in _items)
                {
                    _Writer.Display(item.ToString());
                }
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
            }
        }
        public void readAll()
        {
            try
            {
                foreach (var item in _items)
                {
                    _Writer.DisplayAll(item);
                }
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
            }

        }
    }
}
