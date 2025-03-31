namespace ConsoleEfCoreExp1.Data;

public class AddressEntity
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }

    //  public Guid PersonId { get; set; }

    public DateTime? DateMovedIn { get; set; }
    public DateTime? CreatedOn { get; set; }

    public PersonEntity Person { get; set; } = default!;
}