using System.ComponentModel.DataAnnotations;

namespace ConsoleEfCoreExp1.Data;

public class PersonEntity
{
    /// <summary>
    /// The primary key and unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The date this was created.
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// The id of the processor that is attached to this database connection.
    /// </summary>
    public Guid? AddressId { get; set; }

    /// <summary>
    /// A timestamp that is used for concurrency checking; thus, it makes sure that nothing has modified the record.
    /// </summary>
    /// <remarks>
    /// See https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations#optimistic-concurrency
    /// </remarks>
    [Timestamp]
    public byte[] Version { get; set; } = [];

    /// <summary>
    /// The instance of the processor that is attached to this database connection.
    /// </summary>
    public AddressEntity? Address { get; set; }
}