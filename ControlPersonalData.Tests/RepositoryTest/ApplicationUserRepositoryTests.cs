using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ControlPersonalData.Tests.ContextTest;
using ControlPersonalData.Infra.Data.Repository;

#nullable disable
namespace ControlPersonalData.Tests.RepositoryTest
{
    /// <summary>
    /// The application user repository tests.
    /// </summary>
    public class ApplicationUserRepositoryTests
    {
        #region Tests Success
        /// <summary>
        /// Applications the user repository get all return users.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        [Fact]
        public async Task ApplicationUserRepository_GetAll_ReturnUsers()
        {
            //Arrange
            int pageNumber = 1;
            int pageQuantity = 5;
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetAll(pageNumber, pageQuantity);

            //Assert
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Applications the users repository get filter return users.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        [Fact]
        public async Task ApplicationUsersRepository_GetFilter_ReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetFilter(dbContext.Users.FirstOrDefaultAsync().Result.Email, null, null, null);

            //Assert
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Applications the users repository get status user return users.
        /// </summary>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        [Fact]
        public async Task ApplicationUsersRepository_GetStatusUser_ReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = applicationUserRepository.GetStatusUser(dbContext.Users.FirstOrDefault().UserName);

            //Assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Applications the users repository get user name return users.
        /// </summary>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        [Fact]
        public async Task ApplicationUsersRepository_GetUserName_ReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetUserName(dbContext.Users.FirstOrDefault().UserName);

            //Assert
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Applications the users repository get by id return users.
        /// </summary>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        [Fact]
        public async Task ApplicationUsersRepository_GetById_ReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = await applicationUserRepository.GetById(dbContext.Users.FirstOrDefault().Id);

            //Assert
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Applications the users repository existing CP F return users.
        /// </summary>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        [Fact]
        public async Task ApplicationUsersRepository_ExistingCPF_ReturnUsers()
        {
            //Arrange
            var dbContext = await GetDatabaseContext.GetDatabaseContexts();
            var applicationUserRepository = new ApplicationUserRepository(dbContext);

            //Act
            var result = applicationUserRepository.ExistingCPF(dbContext.Users.FirstOrDefault().CPF);

            //Assert
            result.Should().BeTrue();
        }
        #endregion
    }
}
