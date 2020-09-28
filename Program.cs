using System;

namespace Converter
{
    class ConverterRates
    {
        private double usdRate, eurRate;
        public ConverterRates(double usd, double eur)
        {
            usdRate = usd;
            eurRate = eur;
        }
        public double GetUAH_to_EUR_Rate()
        {
            return 1 / eurRate;
        }
        public double GetEUR_to_UAH_Rate()
        {
            return eurRate;
        }
        public double GetUAH_to_USD_Rate()
        {
            return 1 / usdRate;
        }
        public double GetUSD_to_UAH_Rate()
        {
            return usdRate;
        }
    }
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Please, enter the USD to UAH exchange rate :");
            double usd = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please, enter the EUR to UAH exchange rate :");
            double eur = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            bool successfulInput;
            double exchangeRate = 1;
            string currencyFrom = "";
            string currencyTo = "";
            do
            {
                do
                {
                    successfulInput = true;
                    Console.WriteLine("Currency converter");
                    Console.WriteLine();
                    Console.WriteLine("Please, choose the exchange direction :");
                    Console.WriteLine("[1] USD to UAH");
                    Console.WriteLine("[2] EUR to UAH");
                    Console.WriteLine("[3] UAH to USD");
                    Console.WriteLine("[4] UAH to EUR");
                    Console.WriteLine();
                    Console.WriteLine("Please, choose: ");

                    ConverterRates conv = new ConverterRates(usd, eur);

                    ConsoleKey selectedOption = Console.ReadKey().Key;
                    Console.WriteLine();
                    Console.Clear();

                    if (selectedOption == ConsoleKey.D1)
                    {
                        exchangeRate = conv.GetUSD_to_UAH_Rate();
                        currencyFrom = "USD";
                        currencyTo = "UAH";
                    }
                    else if (selectedOption == ConsoleKey.D2)
                    {
                        exchangeRate = conv.GetEUR_to_UAH_Rate();
                        currencyFrom = "EUR";
                        currencyTo = "UAH";
                    }
                    else if (selectedOption == ConsoleKey.D3)
                    {
                        exchangeRate = conv.GetUAH_to_USD_Rate();
                        currencyFrom = "UAH";
                        currencyTo = "USD";
                    }
                    else if (selectedOption == ConsoleKey.D4)
                    {
                        exchangeRate = conv.GetUAH_to_EUR_Rate();
                        currencyFrom = "UAH";
                        currencyTo = "EUR";
                    }
                    else
                    {
                        successfulInput = false;
                        continue;

                    }
                } while (!successfulInput);

                Console.Clear();
                Console.WriteLine("Please, enter the ammount of {0} you want to exchange : ", currencyFrom);
                double ammount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("{0} of {1} is {2} of {3}", ammount, currencyFrom, ammount * exchangeRate, currencyTo);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            } while (true);
        }
    }
}
