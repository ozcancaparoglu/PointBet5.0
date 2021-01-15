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
        private readonly IApiDbService apiDbService;

        public HomeController(IBaseFactory baseFactory,
            IApiSportService apiSportService,
            IApiDbService apiDbService) : base(baseFactory)
        {
            this.apiSportService = apiSportService;
            this.apiDbService = apiDbService;
        }

        public async Task<IActionResult> Index()
        {
            //var m = await apiDbService.InsertCountries();
            //var o = await apiDbService.InsertSeasons(2019);
            var t = await apiDbService.InsertTeams(203, 2019);

            return View();
        }
    }
}