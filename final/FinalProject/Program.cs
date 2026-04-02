using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        FileManager fileManager = new FileManager("customer_data.txt");
        List<Customer> customers = fileManager.LoadCustomerData();

        Bakery bakery = new Bakery(customers);
        bakery.Start();
    }
}