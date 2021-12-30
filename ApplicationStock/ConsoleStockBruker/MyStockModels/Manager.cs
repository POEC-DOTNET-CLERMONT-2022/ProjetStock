using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    //public  class Manager<TItem>
    //{
    //    public IWriter<TItem> _Writer { get; set; }
    //    public IReader<TItem> _Reader { get; set; }

    //    private IList<TItem> _items { get; set; }

    //    public Manager(IWriter<TItem> writer,IReader<TItem> reader)
    //    {
    //        _Writer = writer;
    //        _Reader = reader;
    //        _Reader.Writer = writer;
    //        _items = new List<TItem>();
    //    }



    //    public void Create()
    //    {
    //        try
    //        {
    //           _items.Add(_Reader.create());
               
               
    //        }
    //        catch (Exception ex)
    //        {
    //            _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
    //        }
    //    }


    //    public void update()
    //    {
    //        try
    //        {
    //          /* _items*/
    //        }
    //        catch (Exception ex)
    //        {
    //            _Writer.Display($"Attention un problème est survenue : {ex.Message}");
    //        }
    //    }
    //    public void delete(TItem item)
    //    {
    //        try
    //        {
    //            _items.Remove(item);
    //        }
    //        catch (Exception ex)
    //        {
    //            _Writer.Display($"Attention un problème est survenue : {ex.Message}");
    //        }

    //    }
    //    public void read()
    //    {
    //        try
    //        {
    //            foreach (var item in _items)
    //            {
    //                _Writer.Display(item.ToString());
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
    //        }
    //    }
    //    public void readAll()
    //    {
    //        try
    //        {
    //            foreach (var item in _items)
    //            {
    //                _Writer.DisplayAll(item);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
    //        }

    //    }
    //}
}
