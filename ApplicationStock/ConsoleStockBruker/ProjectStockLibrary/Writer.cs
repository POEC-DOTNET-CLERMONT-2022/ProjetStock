﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockModels;


namespace ProjectStockLibrary
{
    public class Writer<TItem> : IWriter<TItem>
    {
        public void Display(string s) {
            Console.WriteLine(s);
        
        }

        public void Display(TItem value)
        {
            Console.WriteLine(value);
        }
    }
}
