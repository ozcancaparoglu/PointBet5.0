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
            //var o = await apiDbService.InsertSeasons(2021);
            //var t = await apiDbService.InsertTeams(203, 2019);
            // var v = await apiSportService.GetVenues("","", "","",1579);
            //var s = await apiSportService.GetStandings(283, 2020, 559);
            //var b = await apiDbService.InsertBookMakers();
            //var bet = await apiDbService.InsertBets();
            //var m = await apiSportService.GetMapping();
            //var r = await apiSportService.GetRounds(203, 2020, true);
           // var f = await apiSportService.GetFixtures(null, "", "", 203, 2020, null, "", "");
            return View();
        }
    }
}