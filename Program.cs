using BankAccount.Entities.Exceptions;
using BankAccount.Entities;
using System.Globalization;

namespace BankAccount
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter the account data:");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder name: ");
                string holder = Console.ReadLine();
                Console.Write("Balance: $ ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account a = new Account(number, holder, balance, withdrawLimit);
                Console.WriteLine();
                Console.WriteLine("Account:" + a);

                Console.Write("\nEnter the value of deposit: $ ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                a.Deposit(value);

                Console.WriteLine();
                Console.WriteLine("Account:" + a);
                Console.WriteLine();
                Console.Write("\nEnter the value of withdrawal: $ ");
                value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                a.Withdraw(value);
                Console.WriteLine("Account:" + a);
            }
            catch(DomainException ex)
            {
                Console.WriteLine("Withdraw Error: " + ex.Message);
            } 
            catch(FormatException ex)
            {
                Console.WriteLine("Format Error: " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("UnexpectedError: " + ex.Message);
            }
        }
    }
}

