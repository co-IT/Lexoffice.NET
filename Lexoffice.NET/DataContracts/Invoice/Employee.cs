namespace Lexoffice.NET.DataContracts.Invoice;

public record Employee
{
    public Employee(string name, int number)
    {
        Name = name;
        Number = number;
    }

    public string Name { get; }
    public int Number { get; }
}