using ObjectOrientedProgram.InventoryDataManagementProblems;
using ObjectOrientedProgram.InventoryManagement;
using ObjectOrientedProgram.StcokAccount;
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
                Console.WriteLine("Select option to perform \n1.Json Inventory \n2.Inventory Management \n3.Stock Account Program \n4.Exit");
                int option=Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        InventoryOperation inventory = new InventoryOperation();
                        inventory.ReadJsonfile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\InventoryDataManagementProblems\Inventory.json");
                        break;                     
                    case 2:
                        InventoryDataManagement inventoryDataManagement = new InventoryDataManagement();
                        bool flag1 = true;
                        while (flag1)
                        {
                            Console.WriteLine("Select option to perform \n1 Json File \n2.Add Inventory \n3.Edit \n4.Delete \n5.Exit");
                            int option1= Convert.ToInt32(Console.ReadLine());
                            switch(option1)
                            {
                                case 1:
                                    inventoryDataManagement.ReadJsonFile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\InventoryManagement\InventoryDeatils.json");
                                    break;
                                    case 2:
                                    inventoryDataManagement.AddInventory();
                                    break;
                                    case 3:
                                    inventoryDataManagement.Edit();
                                    break;
                                case 4:
                                    inventoryDataManagement.Delete();
                                    break;
                                case 5:
                                    flag1 = false;
                                    break;
                            }
                        }                                                                              
                        break;
                    case 3:
                        StockOperation stockOperation = new StockOperation();
                        stockOperation.ReadJsonfile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\StcokAccount\Stock.json");
                        break;                       
                   case 4:flag = false;
                        break;
                }
            }
            
            
        }
    }
}