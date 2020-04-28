using System;

namespace ATMMachineTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] accountNumbers = { 111111, 222222, 333333, 444444 };
            int[] pinNumber = { 1111, 2222, 3333, 4444 };

            BankAccount[] accounts = new BankAccount[4];

            for (int x = 0; x < accounts.Length; ++x)
            {
                accounts[x] = new BankAccount(500.00);
            }

            for (int index = 0; index < accounts.Length; ++index)
            {
                accounts[index].AccountNumber = accountNumbers[index];
                accounts[index].PinNumber = pinNumber[index];

            }

            Console.WriteLine("Welcome to the Bank!");
            Console.WriteLine("\nMenu:\n------------------------");
            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Check Balance");
            Console.Write("\nWhat would you like to do: ?");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            Menu(menuChoice, accounts);

        }

        static void Menu(int choice, BankAccount[] acct)
        {
            switch (choice)
            {
                case 1:
                    Deposit(acct);
                    break;
                case 2:
                    Withdraw(acct);
                    break;
                case 3:
                    CheckBalance(acct);
                    break;
                default:
                    Console.WriteLine("That is not an option, please try again.");
                    break;
            }
        }

        static void Deposit(BankAccount[] tempAcctArray)
        {
            int tempAcct = 0, tempPin;
            bool accountFound = false;
            bool pinMatch = false;

            while(!accountFound)
            {
                Console.Write("What is your account number?: ");
                tempAcct = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < tempAcctArray.Length; ++x)
                {
                    if (tempAcct == tempAcctArray[x].AccountNumber)
                    {
                        tempAcct = x;
                        accountFound = true;
                    }
                   
                }
            }
            Console.Write("what is your pin number: ?");
            tempPin = Convert.ToInt32(Console.ReadLine());

            while(!pinMatch)
            {
                if (tempPin == tempAcctArray[tempAcct].PinNumber)
                {
                    pinMatch = true;
                }
                else
                {
                    Console.WriteLine("That PIN does not match the account.");
                    Console.WriteLine("Please enter the correct PIN");
                    tempPin = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.Write("How much would you like to deposit: ?");
            double tempBalance = Convert.ToDouble(Console.ReadLine());

            tempAcctArray[tempAcct].BankBalance += tempBalance;
            Console.WriteLine("\nYou have deposited {0} into your account\nThe new balance is {1}", tempBalance.ToString("c"), tempAcctArray[tempAcct].BankBalance.ToString("c"));
            Console.WriteLine("\nThank you, Press 'Enter' to exit");
        }

        static void Withdraw(BankAccount[] tempAcctArray)
        {
            int tempAcct = 0, tempPin;
            bool accountFound = false;
            bool pinMatch = false;

            while (!accountFound)
            {
                Console.Write("What is your account number?: ");
                tempAcct = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < tempAcctArray.Length; ++x)
                {
                    if (tempAcct == tempAcctArray[x].AccountNumber)
                    {
                        tempAcct = x;
                        accountFound = true;
                    }
                }
            }
            Console.Write("what is your pin number: ?");
            tempPin = Convert.ToInt32(Console.ReadLine());

            while (!pinMatch)
            {
                if (tempPin == tempAcctArray[tempAcct].PinNumber)
                {
                    pinMatch = true;
                }
                else
                {
                    Console.WriteLine("That PIN does not match the account.");
                    Console.WriteLine("Please enter the correct PIN");
                    tempPin = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.Write("How much would you like to withdraw: ?");
            double tempBalance = Convert.ToDouble(Console.ReadLine());
            while (tempBalance > tempAcctArray[tempAcct].BankBalance)
            {
                Console.WriteLine("You cannot exceeed your current balance {0}.", tempAcctArray[tempAcct].BankBalance.ToString("c"));
                Console.Write("How much would you like to withdraw: ?");
                tempBalance = Convert.ToDouble(Console.ReadLine());
            }

            tempAcctArray[tempAcct].BankBalance -= tempBalance;

            Console.WriteLine("\nYou have withdrawn {0} into your account\nThe new balance is {1}", tempBalance.ToString("c"), tempAcctArray[tempAcct].BankBalance.ToString("c"));
            Console.WriteLine("\nThank you, Press 'Enter' to exit");
        }

        static void CheckBalance(BankAccount[] tempAcctArray)
        {
            int tempAcct = 0, tempPin;
            bool accountFound = false;
            bool pinMatch = false;

            while (!accountFound)
            {
                Console.Write("What is your account number?: ");
                tempAcct = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < tempAcctArray.Length; ++x)
                {
                    if (tempAcct == tempAcctArray[x].AccountNumber)
                    {
                        tempAcct = x;
                        accountFound = true;
                    }
                    
                }
            }
            Console.Write("what is your pin number: ?");
            tempPin = Convert.ToInt32(Console.ReadLine());

            while (!pinMatch)
            {
                if (tempPin == tempAcctArray[tempAcct].PinNumber)
                {
                    pinMatch = true;
                }
                else
                {
                    Console.WriteLine("That PIN does not match the account.");
                    Console.WriteLine("Please enter the correct PIN");
                    tempPin = Convert.ToInt32(Console.ReadLine());
                }
            }

      
            Console.WriteLine("\nThe account balance is {0}", tempAcctArray[tempAcct].BankBalance.ToString("c"));
            Console.WriteLine("\nThank you, Press 'Enter' to exit");
        }
    }

    class BankAccount
    {
        private int accountNumber, pinNumber;
        private double bankBalance;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }
        }

        public int PinNumber
        {
            get
            {
                return pinNumber;
            }
            set
            {
                pinNumber = value;
            }
        }

        public double BankBalance
        {
            get
            {
                return bankBalance;
            }
            set
            {
                bankBalance = value;
            }
        }

        public BankAccount(double accountBalance)
        {
            this.BankBalance = accountBalance;
        }

    }
}
