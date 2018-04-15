// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Halcyon.Cms.Lib.Services;
using Halcyon.Cms.Mvc.Controllers;

namespace Halcyon.Cms.Web.Mvc.Controllers
{
    public class InitCmsController : BaseController<InitCmsController>
    {
        public InitCmsController(IHostingEnvironment env) : base(env)
        {
        }

        [HttpGet]
        [Route("")]
        [Route("{culture}")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(GlobalConfigurationService.Instance.GetConfigConnectionKey()))
            {
                return RedirectToAction("Init", "Portal", new { culture = ROUTE_DEFAULT_CULTURE });
            }
            else
            {
                GlobalConfigurationService.Instance.IsInit = true;
                return RedirectToAction("", "Home", new { culture = CurrentLanguage });
            }
        }
    }
}