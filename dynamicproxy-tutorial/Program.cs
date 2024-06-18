// See https://aka.ms/new-console-template for more information
using dynamicproxy_tutorial;

var rex = Freezable.MakeFreezable<Pet>();
rex.Name = "Rex";
Console.WriteLine(Freezable.IsFreezable(rex)
    ? "Rex is freezable!"
    : "Rex is not freezable. Something is not working");
Console.WriteLine(rex.ToString());
Console.WriteLine("Add 50 years");
rex.Age += 50;
Console.WriteLine("Age: {0}", rex.Age);
rex.Deceased = true;

Console.WriteLine("Deceased: {0}", rex.Deceased);
Freezable.Freeze(rex);
try
{
    rex.Age++;
}
catch (ObjectFrozenException)
{
    Console.WriteLine("Oops. it's frozen. Can't change that anymore");
}

Console.WriteLine("--- press enter to close");
Console.ReadLine();
