using Microsoft.EntityFrameworkCore;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Infra.Data.Context;
using System;

#nullable disable
namespace ControlPersonalData.Tests.ContextTest
{
    /// <summary>
    /// The get database context.
    /// </summary>
    public class GetDatabaseContext
    {
        /// <summary>
        /// Gets the database contexts.
        /// </summary>
        /// <returns><![CDATA[A Task<ApplicationDbContext>.]]></returns>
        public static async Task<ApplicationDbContext> GetDatabaseContexts()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (!await databaseContext.Users.AnyAsync())
                 await SeedUserData(databaseContext);

            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        /// <summary>
        /// Seeds the user data.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <returns>A Task.</returns>
        private static async Task SeedUserData(ApplicationDbContext dbContext)
        {
            var users = Enumerable.Range(1, 6).Select(_ => CreateSampleUser()).ToList();
            dbContext.Users.AddRange(users);
        }

        /// <summary>
        /// Creates the sample user.
        /// </summary>
        /// <returns>An ApplicationUser.</returns>
        private static ApplicationUser CreateSampleUser()
        {
            Random random = new();
            string GenerateRandomSequence(int length) => string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(10)));

            return new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "testNewUpdate" + GenerateRandomSequence(2) + "@test.com",
                Name = "testNewUpdate",
                CPF = GenerateRandomSequence(11),
                BirthDate = new DateTime(1996, 10, 21),
                DateInsert = DateTime.Parse("2023-11-06 12:46:50.079"),
                DateAlteration = DateTime.Parse("2023-11-09 09:48:02.168"),
                MotherName = "testNewUpdate",
                Status = true,
                UserName = "TEST" + GenerateRandomSequence(1),
                PasswordHash = "Test@2023",
                PhoneNumber = GenerateRandomSequence(9),
            };
        }
    }
}
