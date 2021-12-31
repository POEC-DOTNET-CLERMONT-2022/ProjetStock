using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    internal class ClientManager
    {
        public IWriterClient _Writer { get; set; }
        public IReaderClient _Reader { get; set; }

        private IList<Client> _items { get; set; }

        public ClientManager(IWriterClient writer, IReaderClient reader)
        {
            _Writer = writer;
            _Reader = reader;
            _Reader.Writer = writer;
            _items = new List<Client>();
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


        public void update(int i, Client client)
        {
            try
            {
                _items[i] = client;
                /* _items*/
            }
            catch (Exception ex)
            {
                _Writer.Display($"Attention un problème est survenue : {ex.Message}");
            }


        }
        public void delete(Client item)
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
