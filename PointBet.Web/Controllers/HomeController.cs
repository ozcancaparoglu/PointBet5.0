using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointBet.Services.ApiServices;
using PointBet.Services.BaseServices;
using System.Threading.Tasks;

namespace PointBet.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IApiSportService apiSportService;

        public HomeController(IBaseFactory baseFactory, IApiSportService apiSportService) : base(baseFactory)
        {
            this.apiSportService = apiSportService;
        }

        public async Task<IActionResult> Index()
        {
            var k = await apiSportService.GetCountries();
            var l = await apiSportService.GetSeasons();
            return View();
        }
    }
}
