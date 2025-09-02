using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Entities;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context) => _context = context;

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync(); // cria/atualiza BD

            if (await _context.Owners.AnyAsync()) return;

            _context.Owners.AddRange(
                new Owner { Document = "1001", FirstName = "Ana", LastName = "Silva", FixedPhone = "212000001", CellPhone = "919000001", Address = "Rua A 1" },
                new Owner { Document = "1002", FirstName = "Bruno", LastName = "Santos", FixedPhone = "212000002", CellPhone = "919000002", Address = "Rua B 2" },
                new Owner { Document = "1003", FirstName = "Carla", LastName = "Costa", FixedPhone = "212000003", CellPhone = "919000003", Address = "Rua C 3" },
                new Owner { Document = "1004", FirstName = "Diogo", LastName = "Ferreira", FixedPhone = "212000004", CellPhone = "919000004", Address = "Rua D 4" },
                new Owner { Document = "1005", FirstName = "Eva", LastName = "Rocha", FixedPhone = "212000005", CellPhone = "919000005", Address = "Rua E 5" },
                new Owner { Document = "1006", FirstName = "Filipe", LastName = "Lopes", FixedPhone = "212000006", CellPhone = "919000006", Address = "Rua F 6" },
                new Owner { Document = "1007", FirstName = "Gustavo", LastName = "Nunes", FixedPhone = "212000007", CellPhone = "919000007", Address = "Rua G 7" },
                new Owner { Document = "1008", FirstName = "Helena", LastName = "Pires", FixedPhone = "212000008", CellPhone = "919000008", Address = "Rua H 8" },
                new Owner { Document = "1009", FirstName = "Igor", LastName = "Marques", FixedPhone = "212000009", CellPhone = "919000009", Address = "Rua I 9" },
                new Owner { Document = "1010", FirstName = "Joana", LastName = "Ramos", FixedPhone = "212000010", CellPhone = "919000010", Address = "Rua J 10" }
            );

            await _context.SaveChangesAsync();
        }
    }
}
