using Newtonsoft.Json;
using ObjectOrientedProgram.InventoryDataManagementProblems;
using ObjectOrientedProgram.StcokAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgram.CommercialDataProcessing
{
    public class StockAccount
    {
        List<StockData> CompanyList;
        List<StockData> stocks;
        StockData stockData = new StockData();
        int amount = 5000;
        public void ReadStockFile(string filepath)
        {
            var data = File.ReadAllText(filepath);
            var result = JsonConvert.DeserializeObject<List<StockData>>(data);
            CompanyList = result;
            Display(result);
        }
        public void ReadCustomerFile(string userfilepath)
        {
            var data = File.ReadAllText(userfilepath);
            var result = JsonConvert.DeserializeObject<List<StockData>>(data);
            stocks = result;
            Display(result);
        }
        public void ValueOf()
        {
            double sum = 0;
            foreach (var item in stocks)
            {
                sum += (item.Shares * item.PricePerShare);

            }
            Console.WriteLine("Total Value of Account Dollars :" + sum);
        }
        public void Display(List<StockData> list)
        {
            foreach (var stock in list)
            {
                Console.WriteLine(stock.ShareName + "\t" + stock.Shares + "\t" + stock.PricePerShare);
            }
        }
        public void Buy()
        {
            Console.WriteLine("Enter Name of the company to buy share");
            string name = Console.ReadLine();
            foreach (var stock in stocks)
            {
                if (stock.ShareName.Equals(name))
                {
                    stockData = stock;
                }
            }
            if (stockData == null)
            {
                Console.WriteLine(name + "" + "with stock not available");
            }
            else
            {
                Console.WriteLine("Enter number of share need to buy");
                int sha = Convert.ToInt32(Console.ReadLine());
                foreach (var data in stocks)
                {
                    if (sha <= data.Shares)
                    {
                        if (amount >= sha * data.PricePerShare)
                        {
                            foreach (var item in CompanyList)
                            {
                                if (item.ShareName == name)
                                {
                                    stockData = item;
                                }
                            }
                            if (stockData == null)
                            {
                                CompanyList.Add(data);
                            }
                            else
                            {
                                foreach (var dataa in CompanyList)
                                {
                                    if (dataa.ShareName.Equals(name))
                                    {
                                        dataa.Shares += sha / 2;
                                    }
                                }
                            }
                            foreach (var datab in stocks)
                            {
                                if (datab.ShareName.Equals(name))
                                {
                                    datab.Shares -= sha / 2;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Stock Account Details\n");
                SaveFileStock(stocks);
            }
            Console.WriteLine("Companies Details\n");
            SaveFileUser(CompanyList);
        }
        public void SellShare()
        {
            Console.WriteLine("Enter Name of the company to sell shares");
                string name = Console.ReadLine();
            foreach (var data in stocks)
            {
                if (data.ShareName.Equals(name))
                {
                    stockData = data;
                }
            }
            if (stockData == null)
            {
                Console.WriteLine(name + " " + "with stocks not available");
            }
            else
            {
                Console.WriteLine("Enter Number of shares need to Sell");
                int shares = Convert.ToInt32(Console.ReadLine());
                foreach (var data in stocks)
                {
                    if (shares <= data.Shares)
                    {
                        if (amount >= shares * data.Shares)
                        {
                            foreach (var datab in CompanyList)
                            {
                                if (datab.ShareName == name)
                                {
                                    stockData = data;
                                }
                            }
                            if (stockData == null)
                            {
                                CompanyList.Add(data);
                            }
                            else
                            {
                                foreach (var datab in CompanyList)
                                {
                                    if (datab.ShareName == name)
                                    {
                                        datab.Shares -= shares / 2;
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var data in stocks)
                {
                    if (data.ShareName.Equals(name))
                    {
                        data.ShareName += shares / 2;
                    }
                }
            }
            Console.WriteLine("Stock Account Deatils\n");
            SaveFileStock(stocks);
            Console.WriteLine("Companies deatils\n");
            SaveFileUser(CompanyList);
        }

        private void SaveFileUser(List<StockData>list)
        {
            string str = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\StcokAccount\StockData.cs", str);
            ReadStockFile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\StcokAccount\StockData.cs");
        }

        private void SaveFileStock(List<StockData>list)
        {
            string str = JsonConvert.SerializeObject(list);
            File.WriteAllText(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessing\User.json",str);
            ReadStockFile(@"D:\BridgeLabs\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessing\User.json");
        }
    }
   
        
}
