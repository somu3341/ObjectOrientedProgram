using ObjectOrientedProgram.InventoryDataManagementProblems;
using ObjectOrientedProgram.InventoryManagement;
using System;
namespace ObjectOrientedProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag) 
            {
                Console.WriteLine("Select option to perform \n1.Json Inventory \n2.Inventory Management \n3.Exit");
                int option=Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        InventoryOperation inventory = new InventoryOperation();
                        inventory.ReadJsonfile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\InventoryDataManagementProblems\Inventory.json");
                        break;
                        case 2:
                        InventoryDataManagement inventoryDataManagement=new InventoryDataManagement();
                        inventoryDataManagement.ReadJsonFile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\InventoryManagement\InventoryDeatils.json");            
                        break;
                   case 3:flag = false;
                        break;
                }
            }
            
            
        }
    }
}