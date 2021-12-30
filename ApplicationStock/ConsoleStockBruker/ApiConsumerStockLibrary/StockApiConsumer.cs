using Newtonsoft.Json.Linq;
using ProjectStockLibrary;
using System.Net;
using System.Text;

namespace ApiConsumerStockLibrary
{
    public class StockApiConsumer
    {
         private static string jsonInd;

        //Fonctions API/JSON

        //Fonction recherche Ingredients
        public static IEnumerable<Stock> GetStock()
        {
      
            using (WebClient wc = new WebClient())
            {
                jsonInd = wc.DownloadString("https://finnhub.io/api/v1/stock/profile?symbol=AAPL&token=c7615giad3i9kvgauiq0");
                //Encodage UTF - 8
                byte[] bytes = Encoding.Default.GetBytes(jsonInd);

                jsonInd = Encoding.UTF8.GetString(bytes);
              

            }

            JObject o = JObject.Parse(jsonInd);
            Console.WriteLine(o);
            List<Stock> lesStocks= new List<Stock>();
          

            return lesStocks;

        }
    
    }
}