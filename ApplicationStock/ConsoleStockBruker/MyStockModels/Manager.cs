using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockModels
{
    public class Manager<TItem>
    {
        public IWriter<TItem> _Writer { get; set; }
        public IReader<TItem> _Reader { get; set; }

        private IList<TItem> _items { get; set; }

        public Manager(IWriter<TItem> writer,IReader<TItem> reader)
        {

            _Writer = writer;

            _Reader = reader;
            _Reader.Writer = writer;
            _items = new List<TItem>();

        }

        public void updateStock()
        {

        }
        public void deleteStock()
        {

        }
        public void readStock()
        {

        }
        public void readAllStock()
        {

        }
    }
}
