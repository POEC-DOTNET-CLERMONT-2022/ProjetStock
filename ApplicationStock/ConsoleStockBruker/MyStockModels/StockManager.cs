using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public class StockManager
    {
            public IWriterStock _Writer { get; set; }
            public IReaderStock _Reader { get; set; }

            private IList<Stock> _items { get; set; }

            public StockManager(IWriterStock writer, IReaderStock reader)
            {
                _Writer = writer;
                _Reader = reader;
                _Reader.Writer = writer;
                _items = new List<Stock>();
            }



            public void Create()
            {
                try
                {
                    _items.Add(_Reader.create());


                }
                catch (Exception ex)
                {
                    _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
                }
            }


            public void update(int i, Stock stock)
            {
            try
            {
                _items[i] = stock;
                /* _items*/
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un problème est survenue : {ex.Message}");
            }
         
            
            }
        public void delete(Stock item)
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

