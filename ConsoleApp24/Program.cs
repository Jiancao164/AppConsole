// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

    var tf = new ClassB("this");
    var ty = new ClassB("ttts");
    var tt = new ClassA(tf);
    var serviceCollection = new ServiceCollection();
    /*serviceCollection.AddSingleton<IThing>(tf);
    serviceCollection.AddSingleton<IThing, ClassB>(); 
     
    serviceCollection.AddSingleton<ClassA>();
    serviceCollection.AddSingleton<IThing, ClassC>();*/
    serviceCollection.AddSingleton<ClassB>(tf);
    serviceCollection.AddSingleton<ClassB>(ty);
    var serviceProvider = serviceCollection.BuildServiceProvider();

    var t = serviceProvider.GetService<ClassB>();
    t!.DoStuff();
 
    Console.WriteLine("Done");
    Console.WriteLine("COMMIT2");
    Console.WriteLine("COMMIT4");


public interface IThing
{
    public void DoStuff();
}
 
public class ClassA
{
    private readonly IThing _dependency;
 
    public ClassA(IThing thing) => _dependency = thing;
 
    public void DoWork() => _dependency.DoStuff();
}
 
public class ClassB : IThing
{
    private string rt;
    public ClassB(string t)
    {
        rt = t;
    }

    public void DoStuff()
    {
        // Imagine implementationc
        Console.WriteLine("do stuff");
        Console.WriteLine(rt);
    }
}
public class ClassC : IThing
{
    public void DoStuff()
    {
        // Imagine implementationc
        Console.WriteLine("do stuff1111");
    }
}