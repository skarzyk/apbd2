namespace Cwiczenia2.Inheritance;

public class B : A
{
    public int MyProperty { get; set; }
    public B(int number, int myProperty) : base(number)
    {
        MyProperty = myProperty;
    }
    
    public override void DoSomething()
    {
        Console.WriteLine("B");
    }
}