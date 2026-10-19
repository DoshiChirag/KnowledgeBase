// See https://aka.ms/new-console-template for more information
using SecureCoding;

DemoClass dm = new DemoClass();
Console.WriteLine(dm.DemoMethod(99, 3));
//Console.WriteLine(dm.DemoMethod(99, 0));
Console.ReadKey();

SavingsAccount account = new SavingsAccount();
if(account is BankAccount)
{
    Console.WriteLine("Savings account is a BankAccount");
}

Console.WriteLine(account.CheckAgeLimit(51));
Console.WriteLine(account.CheckAgeLimit(44));

object o = new SomeClass();
SavingsAccount? sa = o as SavingsAccount;
if(sa != null)
{
    Console.WriteLine(sa.ToString());
}
else
{
    Console.WriteLine("{0}  is not any type of bank account", o.GetType().Name);
}
Console.ReadKey();

Calculator myCalculator = new Calculator();
int y = 5;
myCalculator.DefaultPassing(y);
Console.WriteLine("Value of y after DefaultPassing: {0}", y);

Console.WriteLine(myCalculator.Addup(8));

int MyNumber = 11;
if(myCalculator.PassByRef(ref MyNumber))
{
    Console.WriteLine("MyNumber = {0} is greater than 9", MyNumber);
}
else
{
    Console.WriteLine("MyNumber = {0} is less than or equal to 9", MyNumber);
}

int x;
bool result1 = myCalculator.GoodNumber("455", out x);
bool result2 = myCalculator.GoodNumber("Error", out y);


if (result1)
{
    Console.WriteLine("{0} can be converted to integer", x);
}
if(!result2)
{
    Console.WriteLine("{0}-Value={1} cannot be converted to integer", "Error", y);
}

Console.ReadKey();



