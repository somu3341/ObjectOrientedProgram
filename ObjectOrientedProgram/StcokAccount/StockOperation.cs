using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgram.StcokAccount
{
    public class StockOperation
    {
        public void ReadJsonfile(string filepath)
        {
            var data = File.ReadAllText(filepath);
            var result = JsonConvert.DeserializeObject<List<StockData>>(data);
            foreach (var Stock in result)
            {
                Console.WriteLine(Stock.ShareName + "\t" + Stock.Shares + "\t" + Stock.PricePerShare +  "\t" + Stock.Shares * Stock.Shares);
            }
        }
    }
}
