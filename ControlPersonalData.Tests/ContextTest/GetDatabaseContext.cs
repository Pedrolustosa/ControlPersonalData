using Microsoft.EntityFrameworkCore;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Infra.Data.Context;

#nullable disable
namespace ControlPersonalData.Tests.ContextTest
{
    /// <summary>
    /// The get database context.
    /// </summary>
    public class GetDatabaseContext
    {
        /// <summary>
        /// Get database contexts.
        /// </summary>
        /// <returns><![CDATA[Task<ApplicationDbContext>]]></returns>
        public static async Task<ApplicationDbContext> GetDatabaseContexts()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync().ConfigureAwait(false);
            if (!await databaseContext.Users.AnyAsync().ConfigureAwait(false))
                await SeedUserData(databaseContext).ConfigureAwait(false);
            await databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return databaseContext;
        }

        /// <summary>
        /// Seeds user data.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <returns>A Task</returns>
        private static async Task SeedUserData(ApplicationDbContext dbContext)
        {
            var random = new Random();
            string GenerateRandomSequence(int length) => string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(10)));
            for (int i = 0; i < 5; i++)
            {
                var email = $"user{i}@example.com";
                var userName = $"user{i}";
                var phoneNumber = GenerateRandomSequence(9);
                var name = "testNewUpdate";
                var cpf = GenerateRandomSequence(11);
                var birthDate = new DateTime(1996, 10, 21);
                var motherName = "testNewUpdate";
                var status = true;
                var user = new ApplicationUser(email, userName, phoneNumber, name, cpf, birthDate, motherName, status);
                dbContext.Users.Add(user);
            }
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
