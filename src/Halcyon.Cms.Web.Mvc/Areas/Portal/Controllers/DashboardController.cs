// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Halcyon.Cms.Lib.ViewModels;
using Halcyon.Cms.Mvc.Controllers;

namespace Halcyon.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Dashboard")]
    public class DashboardController : BaseController<DashboardController>
    {
        public DashboardController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> pageLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        //[Route("/portal/Dashboard")]
        [HttpGet]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public IActionResult Index(string keyword, int pageSize = 10, int pageIndex = 0)
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            return View(dashboard);
        }
    }
}
