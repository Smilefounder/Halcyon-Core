// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Halcyon.Cms.Lib.ViewModels.Info;
using System.Collections.Generic;
using System.Linq;

namespace Halcyon.Cms.Mvc.ViewComponents
{
    public class FooterNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string culture = ViewBag.culture;
            var topCates = new List<InfoCategoryViewModel>();
            //Halcyon.Cms.Lib.ViewModels.Info.InfoCategoryViewModel.Repository.GetModelListBy
            //(c => c.Specificulture == culture && c.TtsCategoryPosition.Count(
            //    p => p.Position == (int)Constants.CatePosition.Footer) > 0

            //);
            return View(topCates.OrderBy(c => c.Priority).ToList());
        }
    }
}