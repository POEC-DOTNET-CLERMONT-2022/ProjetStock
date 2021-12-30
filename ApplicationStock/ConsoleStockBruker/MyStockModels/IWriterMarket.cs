﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace MyStockModels
{
    public interface IWriterMarket
    {
        public void Display(string s);

        public void DisplayAll(Market item);

        public void DisplayAllStocks(List<Stock> stocks);

    }
}
