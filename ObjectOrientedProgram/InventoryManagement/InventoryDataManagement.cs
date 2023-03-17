using Newtonsoft.Json;
using ObjectOrientedProgram.InventoryDataManagementProblems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgram.InventoryManagement
{
    public class InventoryDataManagement
    {
        List<InventoryData> riceList;
        List<InventoryData> wheatList;
            List<InventoryData> pulsesList;
        public void ReadJsonFile(string filepath) 
        {
            var data = File.ReadAllText(filepath);
            var result = JsonConvert.DeserializeObject<InventoryList>(data);
             riceList = result.RiceList;
            Display(riceList);
             wheatList = result.WheatList;
            Display(wheatList);
            pulsesList = result.PulsesList;
            Display(pulsesList);
        }
        public void Display(List<InventoryData>list)
        {
            foreach (var inventory in list) 
            {
                Console.WriteLine(inventory.Name + "\t" + inventory.Weight +
                    "\t" + inventory.PricePerKg + "\t" + inventory.Weight * inventory.PricePerKg);
            }
        }      
    }
}
