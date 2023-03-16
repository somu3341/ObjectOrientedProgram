using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectOrientedProgram.InventoryDataManagementProblems
{
   public class InventoryOperation
    {
        public void ReadJsonfile(string filepath)
        {
            var data=File.ReadAllText(filepath);
            var result = JsonConvert.DeserializeObject<List<InventoryData>>(data);
            foreach (var inventory in result)
            {
                Console.WriteLine(inventory.Name + "\t" + inventory.Weight + "\t" + inventory.PricePerKg +
                      "\t" + inventory.Weight * inventory.PricePerKg);
            }
        }
    }
}
