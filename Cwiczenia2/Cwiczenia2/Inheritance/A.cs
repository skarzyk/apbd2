namespace Cwiczenia2.Inheritance;

public class A : IMyInterface
{
    // Wlasciwosc
    public int Number { get; set; }
    public A(int number)
    {
        Number = number;
    }

    public virtual void DoSomething()
    {
        Console.WriteLine("A");
    }
}