using Bogus;

namespace DotNetCoreApi.Model
{
    public static class DataGenerator
    {
        public const int NumberOfEmployees = 5;
        public const int NumberOfVehiclesPerEmployee = 2;
        public static readonly List<Employee> Employees = new();
        public static readonly List<Vehicle> Vehicles = new();
        public static void InitBogusData()
        {
            var employeeGenerator = GetEmployeeGenerator();
            var generatedEmployees = employeeGenerator.Generate(NumberOfEmployees);
            Employees.AddRange(generatedEmployees);
        }
        private static Faker<Vehicle> GetVehicleGenerator(Guid employeeId)
        {
            return new Faker<Vehicle>()
                .RuleFor(v => v.Id, _ => Guid.NewGuid())
                .RuleFor(v => v.EmployeeId, _ => employeeId)
                .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());
        }
        private static Faker<Employee> GetEmployeeGenerator()
        {
            return new Faker<Employee>()
                .RuleFor(e => e.Id, _ => Guid.NewGuid())
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.AboutMe, f => f.Lorem.Paragraph(1))
                .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 90))
                .RuleFor(e => e.Personality, f => f.PickRandom<Personality>())
                .RuleFor(e => e.Vehicles, (_, e) =>
                {
                    return GetBogusVehicleData(e.Id);
                });
        }
        private static List<Vehicle> GetBogusVehicleData(Guid employeeId)
        {
            var vehicleGenerator = GetVehicleGenerator(employeeId);
            var generatedVehicles = vehicleGenerator.Generate(NumberOfVehiclesPerEmployee);
            Vehicles.AddRange(generatedVehicles);
            return generatedVehicles;
        }
    }
}
