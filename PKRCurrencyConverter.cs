using System;
using System.Collections.Generic;

namespace PKRCurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PKR Currency Converter");
            Console.WriteLine("=====================");

            // Create currency converter
            CurrencyConverter converter = new CurrencyConverter();

            while (true)
            {
                try
                {
                    // Get amount in PKR from user
                    Console.Write("\nEnter amount in Pakistani Rupees (PKR) or type 'exit' to quit: ");
                    string input = Console.ReadLine();

                    // Check if user wants to exit
                    if (input.ToLower() == "exit")
                    {
                        break;
                    }

                    // Parse input to decimal
                    if (!decimal.TryParse(input, out decimal pkrAmount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    // Convert and display all currencies
                    Console.WriteLine("\n--- Conversion Results ---");
                    
                    // Get all available currencies
                    Dictionary<string, decimal> conversions = converter.ConvertFromPKR(pkrAmount);
                    
                    // Display each conversion
                    foreach (var conversion in conversions)
                    {
                        Console.WriteLine($"{pkrAmount:N2} PKR = {conversion.Value:N2} {conversion.Key}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            Console.WriteLine("\nThank you for using PKR Currency Converter!");
        }
    }

    class CurrencyConverter
    {
        // Dictionary to store exchange rates (PKR to other currencies)
        private Dictionary<string, decimal> exchangeRates;

        public CurrencyConverter()
        {
            // Initialize exchange rates (as of April 2025, for demonstration purposes)
            // In a real application, these would be fetched from an API
            exchangeRates = new Dictionary<string, decimal>
            {
                { "USD", 0.0036m },  // US Dollar
                { "EUR", 0.0033m },  // Euro
                { "GBP", 0.0028m },  // British Pound
                { "JPY", 0.55m },    // Japanese Yen
                { "AUD", 0.0054m },  // Australian Dollar
                { "CAD", 0.0049m },  // Canadian Dollar
                { "CHF", 0.0032m },  // Swiss Franc
                { "CNY", 0.026m },   // Chinese Yuan
                { "INR", 0.30m },    // Indian Rupee
                { "SAR", 0.014m },   // Saudi Riyal
                { "AED", 0.013m },   // UAE Dirham
                { "MYR", 0.017m },   // Malaysian Ringgit
                { "SGD", 0.0048m },  // Singapore Dollar
                { "TRY", 0.12m },    // Turkish Lira
                { "RUB", 0.33m },    // Russian Ruble
                { "BRL", 0.020m },   // Brazilian Real
                { "ZAR", 0.066m },   // South African Rand
                { "KRW", 4.9m },     // South Korean Won
                { "EGP", 0.17m },    // Egyptian Pound
                { "BDT", 0.40m }     // Bangladeshi Taka
            };
        }

        // Method to convert PKR to all available currencies
        public Dictionary<string, decimal> ConvertFromPKR(decimal pkrAmount)
        {
            Dictionary<string, decimal> results = new Dictionary<string, decimal>();

            foreach (var rate in exchangeRates)
            {
                results[rate.Key] = pkrAmount * rate.Value;
            }

            return results;
        }

        // Get available currencies
        public List<string> GetAvailableCurrencies()
        {
            return new List<string>(exchangeRates.Keys);
        }
    }
}