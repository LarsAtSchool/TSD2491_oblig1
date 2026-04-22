using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TSD2491_oblig1_031688.Models;

namespace TSD2491_oblig1_031688.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {

            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { FirstName = "Per",      LastName = "Hansen",     StudentNumber = "1001", HasActiveLoan = false },
                    new Student { FirstName = "Anna",     LastName = "Lund",       StudentNumber = "1002", HasActiveLoan = false },
                    new Student { FirstName = "Jonas",    LastName = "Solberg",    StudentNumber = "1003", HasActiveLoan = false },
                    new Student { FirstName = "Ingrid",   LastName = "Berg",       StudentNumber = "1004", HasActiveLoan = false },
                    new Student { FirstName = "Marius",   LastName = "Nilsen",     StudentNumber = "1005", HasActiveLoan = false },
                    new Student { FirstName = "Sara",     LastName = "Aas",        StudentNumber = "1006", HasActiveLoan = false },
                    new Student { FirstName = "Emil",     LastName = "Karlsen",    StudentNumber = "1007", HasActiveLoan = false },
                    new Student { FirstName = "Thea",     LastName = "Johansen",   StudentNumber = "1008", HasActiveLoan = false },
                    new Student { FirstName = "Oliver",   LastName = "Myhre",      StudentNumber = "1009", HasActiveLoan = false },
                    new Student { FirstName = "Nora",     LastName = "Strand",     StudentNumber = "1010", HasActiveLoan = false },

                    new Student { FirstName = "Lars",      LastName = "Kristoffersen", StudentNumber = "1011", HasActiveLoan = false },
                    new Student { FirstName = "Hanne",     LastName = "Brekke",        StudentNumber = "1012", HasActiveLoan = false },
                    new Student { FirstName = "Sindre",    LastName = "Vik",           StudentNumber = "1013", HasActiveLoan = false },
                    new Student { FirstName = "Elise",     LastName = "Moe",           StudentNumber = "1014", HasActiveLoan = false },
                    new Student { FirstName = "Tobias",    LastName = "Holt",          StudentNumber = "1015", HasActiveLoan = false },
                    new Student { FirstName = "Kaja",      LastName = "Fjeld",         StudentNumber = "1016", HasActiveLoan = false },
                    new Student { FirstName = "Henrik",    LastName = "Rønning",       StudentNumber = "1017", HasActiveLoan = false },
                    new Student { FirstName = "Mina",      LastName = "Sørensen",      StudentNumber = "1018", HasActiveLoan = false },
                    new Student { FirstName = "Andreas",   LastName = "Haug",          StudentNumber = "1019", HasActiveLoan = false },
                    new Student { FirstName = "Julie",     LastName = "Borge",         StudentNumber = "1020", HasActiveLoan = false },

                    new Student { FirstName = "Kristian",  LastName = "Dahl",          StudentNumber = "1021", HasActiveLoan = false },
                    new Student { FirstName = "Vilde",     LastName = "Løken",         StudentNumber = "1022", HasActiveLoan = false },
                    new Student { FirstName = "Martin",    LastName = "Aune",          StudentNumber = "1023", HasActiveLoan = false },
                    new Student { FirstName = "Silje",     LastName = "Tangen",        StudentNumber = "1024", HasActiveLoan = false },
                    new Student { FirstName = "Eirik",     LastName = "Hustad",        StudentNumber = "1025", HasActiveLoan = false },
                    new Student { FirstName = "Oda",       LastName = "Helle",         StudentNumber = "1026", HasActiveLoan = false },
                    new Student { FirstName = "Sebastian", LastName = "Larsen",        StudentNumber = "1027", HasActiveLoan = false },
                    new Student { FirstName = "Maria",     LastName = "Østby",         StudentNumber = "1028", HasActiveLoan = false },
                    new Student { FirstName = "Jørgen",    LastName = "Sandvik",       StudentNumber = "1029", HasActiveLoan = false },
                    new Student { FirstName = "Helene",    LastName = "Myklebust",     StudentNumber = "1030", HasActiveLoan = false }
                );
            }


            if (!context.Devices.Any())
            {
                context.Devices.AddRange(
                    new Device { Name = "Dell Laptop",       DeviceType = "Laptop",   ModelName = "Latitude 5420", Specifications = "i5, 16GB RAM, 512GB SSD", IsAvailable = true },
                    new Device { Name = "iPad",              DeviceType = "Tablet",   ModelName = "iPad 9th Gen", Specifications = "64GB, WiFi",              IsAvailable = true },
                    new Device { Name = "Samsung Tablet",    DeviceType = "Tablet",   ModelName = "Galaxy Tab A8", Specifications = "64GB, WiFi",             IsAvailable = true },
                    new Device { Name = "HP Laptop",         DeviceType = "Laptop",   ModelName = "ProBook 450", Specifications = "i5, 8GB RAM, 256GB SSD",   IsAvailable = true },
                    new Device { Name = "MacBook Air",       DeviceType = "Laptop",   ModelName = "M1", Specifications = "8GB RAM, 256GB SSD",                IsAvailable = true },
                    new Device { Name = "Lenovo ThinkPad",   DeviceType = "Laptop",   ModelName = "T14", Specifications = "i7, 16GB RAM, 512GB SSD",          IsAvailable = true },
                    new Device { Name = "Surface Pro",       DeviceType = "Tablet",   ModelName = "Surface Pro 7", Specifications = "i5, 8GB RAM",            IsAvailable = true },
                    new Device { Name = "Asus Chromebook",   DeviceType = "Laptop",   ModelName = "C423", Specifications = "ChromeOS, 4GB RAM",               IsAvailable = true },
                    new Device { Name = "Acer Laptop",       DeviceType = "Laptop",   ModelName = "Aspire 5", Specifications = "i3, 8GB RAM, 256GB SSD",      IsAvailable = true },
                    new Device { Name = "Huawei Tablet",     DeviceType = "Tablet",   ModelName = "MatePad 10.4", Specifications = "64GB, WiFi",              IsAvailable = true }
                );
            }

            context.SaveChanges();
        }
    }
}

