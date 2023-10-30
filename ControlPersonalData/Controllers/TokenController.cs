using Microsoft.AspNetCore.Mvc;

namespace ControlPersonalData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
    }
}
