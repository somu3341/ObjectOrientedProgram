using Newtonsoft.Json;
using ObjectOrientedProgram.InventoryDataManagementProblems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public void Display(List<InventoryData> list)
        {
            foreach (var inventory in list)
            {
                Console.WriteLine(inventory.Name + "\t" + inventory.Weight +
                    "\t" + inventory.PricePerKg + "\t" + inventory.Weight * inventory.PricePerKg);
            }
        }
        public void AddInventory()
        {
            Console.WriteLine("Enter in which list new inventory need to be added");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Inventory Data");
            InventoryData data = new InventoryData();
            data.Name = Console.ReadLine();
            data.Weight = Convert.ToDouble(Console.ReadLine());
            data.PricePerKg = Convert.ToDouble(Console.ReadLine());
            if (name.ToLower().Equals("rice"))
            {
                riceList.Add(data);
                Display(riceList);
            }
            if (name.ToLower().Equals("wheat"))
            {
                wheatList.Add(data);
                Display(wheatList);
            }
            if (name.ToLower().Equals("pulses"))
            {
                pulsesList.Add(data);
                Display(pulsesList);
            }
            
        }
        public void Edit()
        {
            Console.WriteLine("Enter which data to be edited");
            string result = Console.ReadLine();
            if (result.ToLower().Equals("rice"))
            {
                foreach (var product in riceList)
                {
                    Console.WriteLine("Enter name of rice");
                    product.Name = Console.ReadLine();
                    Console.WriteLine("Enter weight of rice");
                    product.Weight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter price of rice per kg");
                    product.PricePerKg = Convert.ToDouble(Console.ReadLine());
                }
                Display(riceList);
            }
            if (result.ToLower().Equals("wheat"))
            {
                foreach (var product in wheatList)
                {
                    Console.WriteLine("Enter name of wheat");
                    product.Name = Console.ReadLine();
                    Console.WriteLine("Enter weight of wheat");
                    product.Weight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter price of wheat per kg");
                    product.PricePerKg = Convert.ToDouble(Console.ReadLine());
                }
                Display(wheatList);
            }
            if (result.ToLower().Equals("pulses"))
            {
                foreach (var product in pulsesList)
                {
                    Console.WriteLine("Enter name of pulses");
                    product.Name = Console.ReadLine();
                    Console.WriteLine("Enter weight of pulses");
                    product.Weight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter price of pulses per kg");
                    product.PricePerKg = Convert.ToDouble(Console.ReadLine());
                }
                Display(pulsesList);
            }
        }
        public void Delete()
        {
            InventoryData inventoryData = new InventoryData();
            Console.WriteLine("Enter in which list you want to delete data");
            string name=Console.ReadLine();
            if (name.ToLower().Equals("rice"))
            {
                foreach (var product in riceList)
                {
                    inventoryData = product;
                }
                riceList.Remove(inventoryData);
                Display(riceList);
            }
            if (name.ToLower().Equals("wheat"))
            {
                foreach (var product in wheatList)
                {
                    inventoryData = product;
                }
                wheatList.Remove(inventoryData);
                Display(wheatList);
            }
            if (name.ToLower().Equals("pulses"))
            {
                foreach (var product in pulsesList)
                {
                    inventoryData = product;
                }
                pulsesList.Remove(inventoryData);
                Display(pulsesList);
            }
        }
    }
}
