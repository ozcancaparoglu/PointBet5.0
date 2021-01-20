using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointBet.Data.Domains;
using PointBet.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PointBet.Services.ApiServices;
using PointBet.Data.Models;

namespace PointBet.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Authorize(Roles = "Admin,Super,God")]
    public class HomeController : BaseController
    {

        #region PreReservedCrudMethods

        private readonly IBaseService<User, UserModel> userCrud;
        #endregion

        private readonly IApiSportService _apisport;
        private IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider, IBaseFactory baseFactory, IConfiguration configuration, IApiSportService apisport) : base(baseFactory)
        {
            userCrud = baseFactory.GetBaseService<User, UserModel>();
            _configuration = configuration;
            _apisport = apisport;
            _serviceProvider = serviceProvider;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}