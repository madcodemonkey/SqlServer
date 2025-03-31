using ConsoleEfCoreExp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

AddMyDependencies(builder.Services, builder.Configuration);

using IHost host = builder.Build();

await host.Services.ApplyDatabaseMigrationsAsync();

//await CreatePersonAsync(host.Services, "Bob", "Hope");
//await CreatePersonAsync(host.Services, "James", "Dean");

//await UpdateAddressAsync(host.Services, "Bob", "Hope");
//await UpdateAddressAsync(host.Services, "James", "Dean");

//await ClearAddressAsync(host.Services, "Bob", "Hope");
await ClearAddressAsync(host.Services, "James", "Dean");

await host.StopAsync();


// Register your dependencies here
static void AddMyDependencies(IServiceCollection serviceCollection, IConfiguration config)
{
    serviceCollection.AddAcmeRepositories(config);
}


static async Task CreatePersonAsync(IServiceProvider serviceProvider, string firstName, string lastName)
{
    var dbContext = serviceProvider.GetRequiredService<AcmeDbContext>();

    if (dbContext.People.Any(w => w.FirstName == firstName && w.LastName == lastName))
    {
        Console.WriteLine($"Person with {firstName} {lastName} already exists!");
        return;
    }

    var person = new PersonEntity()
    {
        FirstName = firstName,
        LastName = lastName,
        CreatedOn = DateTime.UtcNow
    };

    await dbContext.People.AddAsync(person);
    await dbContext.SaveChangesAsync();
    Console.WriteLine($"Created with {firstName} {lastName} with id {person.Id}!");

}

static async Task UpdateAddressAsync(IServiceProvider serviceProvider, string firstName, string lastName)
{
    var dbContext = serviceProvider.GetRequiredService<AcmeDbContext>();
    var person = dbContext.People.FirstOrDefault(
        w => w.FirstName == firstName &&
             w.LastName == lastName &&
             w.Address == null);

    if (person == null)
    {
        Console.WriteLine($"No person named {firstName} {lastName} found without an address!");
        return;
    }

    person.Address = new AddressEntity
    {
        Street = "416 Sid Snyder Avenue SW",
        City = "Olympia",
        State = "WA",
        PostalCode = "98504",
        CreatedOn = DateTime.UtcNow,
        DateMovedIn = DateTime.UtcNow.AddYears(-2)
    };


    dbContext.People.Update(person);
    await dbContext.SaveChangesAsync();
}


static async Task ClearAddressAsync(IServiceProvider serviceProvider, string firstName, string lastName)
{
    var dbContext = serviceProvider.GetRequiredService<AcmeDbContext>();
    var person = dbContext.People
        .Include(i => i.Address)
        .FirstOrDefault(
        w => w.FirstName == firstName &&
             w.LastName == lastName &&
             w.Address != null);

    if (person == null)
    {
        Console.WriteLine($"No person named {firstName} {lastName} found with an address!");
        return;
    }

    if (person.Address != null)
    {
        dbContext.Addresses.Remove(person.Address);
    }

    person.AddressId = null;
    person.Address = null;

    dbContext.People.Update(person);
    await dbContext.SaveChangesAsync();
}


