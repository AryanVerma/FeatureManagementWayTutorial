using System.Text.Json;

namespace DotNetCoreApi.Model
{
    public enum Personality
    {
        Positive,
        Negative,
        Neutral
    }
    public sealed class Vehicle
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Manufacturer { get; set; } = default!;
        public string Fuel { get; set; } = default!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
    public sealed class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string AboutMe { get; set; } = default!;
        public int YearsOld { get; set; }
        public Personality Personality { get; set; }
        public List<Vehicle> Vehicles { get; set; } = default!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
