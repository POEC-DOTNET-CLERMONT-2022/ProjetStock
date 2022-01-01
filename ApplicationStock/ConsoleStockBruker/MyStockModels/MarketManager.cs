using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;


namespace MyStockModels
{
    public class MarketManager
    {
            public IWriterMarket _Writer { get; set; }
            public IReaderMarket _Reader { get; set; }

            private IList<Market> _items { get; set; }

            public MarketManager(IWriterMarket writer, IReaderMarket reader)
            {
                _Writer = writer;
                _Reader = reader;
                _Reader.Writer = writer;
                _items = new List<Market>();
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


        public void update(int i)
        {
            try
            {
                _items[i] = _Reader.update(_items[i]);
           
                /* _items*/
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un problème est survenue : {ex.Message}");
            }


        }
        public void delete(Market item)
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
        public void delete(int i)
        {
            try
            {
                _items.Remove(_items[i]);
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

