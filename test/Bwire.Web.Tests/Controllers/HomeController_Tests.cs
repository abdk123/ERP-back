using System.Threading.Tasks;
using Bwire.Models.TokenAuth;
using Bwire.Web.Controllers;
using Shouldly;
using Xunit;

namespace Bwire.Web.Tests.Controllers
{
    public class HomeController_Tests: BwireWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}