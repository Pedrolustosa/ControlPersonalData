using Xunit;
using FluentAssertions;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Infra.Data.Repository;
using ControlPersonalData.Tests.ContextTest;

#nullable disable
namespace ControlPersonalData.Tests.RepositoryTest
{
    /// <summary>
    /// The pokemon repository tests.
    /// </summary>
    public class ApplicationUserRepositoryTests
    { 
        /// <summary>
        /// Applications the user repository get all users.
        /// </summary>
        [Fact]
        public async Task<List<ApplicationUser>> ApplicationUserRepositoryGetAllReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            int pageNumber = 1;
            int pageQuantity = 10;
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetAll(pageNumber, pageQuantity);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<ApplicationUser>>();
            return result;
        }

        /// <summary>
        /// Applications the users repository get filter return users.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        [Fact]
        public async Task<IEnumerable<ApplicationUser>> ApplicationUsersRepositoryGetFilterReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetFilter(dbContext.Users.FirstOrDefault().Email, 
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<ApplicationUser>>();
            return result;
        }
    }
}
