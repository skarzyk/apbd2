using Cwiczenia2.Inheritance;

{
    int number = 10;
    string text = "Text: " + number +".";
    string textWithDollar = $"Text: {number}.";
    
    var k = "text";
    
    // Nullable
    int? nullableInt = null;
    nullableInt = 4;
    Object? o = null;
}

// Kolekcje
{
    
    var list = new List<int>();
    list.Add(10);
    
    var dict = new Dictionary<string, int>();
    dict.Add("klucz", 10);
}

// Bledy
{
    try
    {
        throw new Exception();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

A a = new A(1);
A b = new B(1, 2);

a.DoSomething();
b.DoSomething();