using AutoMapper;
using ProjectStockDTOS;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Services
{
    public class MarketServiceReader : JsonGenericReader<MarketModel, MarketDto>
    {


        public MarketServiceReader(HttpClient httpClient, IMapper mapper) : base(httpClient, "api/Market", mapper)
        {

        }



    }
}
