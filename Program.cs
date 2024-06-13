using ATM_class.EX2;
using ATM_class.Exceptions;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
class Program
{
    class ATM
    {
        public int Balance { get; set; }
        public int Pin { get; set; }
        public ATM(int balance = 500, int pin = 12345)
        {
            Balance = balance;
            Pin = pin;
        }
        public int ShowBalance()
        {
            return Balance;
        }
        public void Withdraw(int amount)
        {
            //Balance -= amount;
            try
            {
                if (amount > Balance)
                {
                    throw new İncorrectAmountException("Not enough money!");
                }
                else
                {
                    Balance -= amount;

                }
            }
            catch (İncorrectAmountException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public bool CheckingPin(int pin)
        {
            if (Pin == pin) return true;
            return false;
        }
        public void AddMoney(int amount)
        {
            Balance += amount;
        }

        public bool Start(int trying, string check)
        {
            for (int i = 0; i < 3; i++)

            {
                Console.WriteLine("Enter Pin: ");
                try
                {// trying = Convert.ToInt32(Console.ReadLine()); 

                    //check = Console.ReadLine();
                    bool isNumericc = int.TryParse(check, out trying);
                    if (isNumericc == false)
                    {
                        throw new WrongTypeException("Wrong type!");

                    }
                    else
                    {
                        trying = 123;
                        return true;
                    }

                }
                catch (WrongTypeException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;

                }
                catch (Exception ex) { Console.WriteLine(ex.Message);
                    return false;
                }

            }
            return false;
        }
    }
    static void Main(string[] args)
    {
        ATM atm = new ATM();
        int trying = 0 ;
        string check;
        bool exit = false;
        Console.WriteLine("Enter Pin: ");
        check = Console.ReadLine();

            /*for (int i = 0; i < 3; i++)

            {
                Console.WriteLine("Enter Pin: ");
                try
                {// trying = Convert.ToInt32(Console.ReadLine()); 
                    int trying=0;
                    check = Console.ReadLine();
                    bool isNumericc=int.TryParse(check, out trying);
                    if (isNumericc == false)
                    {
                        throw new WrongTypeException("Wrong type!");
                    }
                    else  {
                        trying = 123; 
                    }

                }
                catch (WrongTypeException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }*/
            if (atm.Start(trying, check)==true)
        {

        
            if (atm.CheckingPin(trying))
            {

                Console.WriteLine("successful login");
                while (exit == false)
                {
                    Console.WriteLine("1.View balance \n 2.Withdraw money from the balance \n 3.Adding money to the balance \n 4.Change pin \n 5.Exit");
                    int choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Console.Write(atm.Balance);
                            Console.WriteLine("AZN");
                            break;
                        case 2:
                            Console.WriteLine("The amount you will withdraw: ");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            atm.Withdraw(amount);

                            break;
                        case 3:
                            Console.WriteLine("the amount you will add");
                            amount = Convert.ToInt32(Console.ReadLine());
                            atm.AddMoney(amount);

                            break;
                        case 4:
                            Console.WriteLine("new pin: ");
                            atm.Pin = Convert.ToInt32(Console.ReadLine());

                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                    
                }
                //break;

            }
            else
            {
                Console.WriteLine("Wrong pin!");
                //continue;
            }
        }


    }

}
