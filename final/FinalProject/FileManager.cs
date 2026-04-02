using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    private string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
    }

    public List<Customer> LoadCustomerData()
    {
        List<Customer> customers = new List<Customer>();

        if (File.Exists(_filePath))
        {
            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 2 && int.TryParse(parts[1], out int loyaltyPoints))
                {
                    string name = parts[0];
                    customers.Add(new Customer(name, loyaltyPoints));
                }
            }
        }

        return customers;
    }

    public void SaveCustomerData(List<Customer> customers)
    {
        try
        {
            Dictionary<string, int> customerData = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            if (File.Exists(_filePath))
            {
                string[] existingLines = File.ReadAllLines(_filePath);
                foreach (string line in existingLines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 2 && int.TryParse(parts[1], out int points))
                    {
                        string name = parts[0];
                        customerData[name] = points;
                    }
                }
            }

            foreach (Customer c in customers)
            {
                string name = c.GetName();
                int currentPoints = c.GetLoyaltyPoints();
                int previousPointsInFile = customerData.ContainsKey(name) ? customerData[name] : 0;

                int pointsToAdd = currentPoints - previousPointsInFile;
                if (pointsToAdd < 0) pointsToAdd = 0;

                if (customerData.ContainsKey(name))
                {
                    customerData[name] += pointsToAdd;
                }
                else
                {
                    customerData[name] = pointsToAdd;
                }
            }

            List<string> linesToWrite = new List<string>();
            foreach (var kvp in customerData)
            {
                linesToWrite.Add($"{kvp.Key},{kvp.Value}");
            }

            File.WriteAllLines(_filePath, linesToWrite);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving customer data: {ex.Message}");
        }
    }
}