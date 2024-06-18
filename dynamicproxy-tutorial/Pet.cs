namespace dynamicproxy_tutorial;

public class Pet
{
    public virtual string Name { get; set; }
    public virtual int Age { get; set; }
    public virtual bool Deceased { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Deceased: {Deceased}";
    }
}