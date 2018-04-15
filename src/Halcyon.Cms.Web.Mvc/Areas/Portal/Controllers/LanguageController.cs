// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Cms.Lib.Services;
using Halcyon.Cms.Lib.ViewModels.BackEnd;
using Halcyon.Cms.Mvc.Controllers;
using Halcyon.Domain.Core.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Halcyon.Cms.Web.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/language")]
    public class LanguageController : BaseController<LanguageController>
    {
        //private readonly GlobalConfigurationService _appService;
        public LanguageController(IHostingEnvironment env
            //, IStringLocalizer<SharedResource> localizer
            //, GlobalConfigurationService service
            )
            : base(env)
        {
            //_appService = service;
        }

        #region Languages

        [HttpGet]
        [Route("")]
        [Route("list")]
        public IActionResult Languages()
        {
            PaginationModel<BELanguageViewModel> pagingPages = new PaginationModel<BELanguageViewModel>()
            {
                Items = GlobalLanguageService.ListLanguage.Where(m => m.Specificulture == CurrentLanguage).ToList(),
                PageIndex = 0,
                PageSize = GlobalLanguageService.ListLanguage.Count(m => m.Specificulture == CurrentLanguage),
                TotalItems = GlobalLanguageService.ListLanguage.Count(m => m.Specificulture == CurrentLanguage),
                TotalPage = 1
            };
            //  await LanguageRepository.GetInstance().GetModelListByAsync(m=> m.Specificulture == _lang,
            //cate => cate.Description, "desc",
            //pageSize, pageIndex, Halcyon.Cms.Lib.SWCmsConstants.ViewModelType.FrontEnd);
            return View(pagingPages);
        }

        // GET: Create
        [HttpGet]
        [Route("Create")]
        public IActionResult CreateLanguage()
        {
            BELanguageViewModel ttsLanguage = new BELanguageViewModel(
                new SiocLanguage()
                {
                    //Id = LanguageRepository.GetInstance().GetNextId()
                    Specificulture = CurrentLanguage
                });
            return View(ttsLanguage);
        }

        // POST: Language/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLanguage(BELanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                var result = await language.SaveModelAsync().ConfigureAwait(false);// BELanguageViewModel.Repository.CreateModelAsync(ttsLanguage);
                if (result.IsSucceed)
                {
                    GlobalLanguageService.Instance.Refresh();
                    return RedirectToAction("Languages");
                }
                else
                {
                    if (result.Exception != null)
                    {
                        ModelState.AddModelError(string.Empty, result.Exception?.Message);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    return View(language);
                }
            }
            else
            {
                return View(language);
            }
        }

        // GET: Language/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> EditLanguage(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsLanguage = await BELanguageViewModel.Repository.GetSingleModelAsync(
                m => m.Keyword == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (ttsLanguage == null)
            {
                return NotFound();
            }
            return View(ttsLanguage.Data);
        }

        // POST: Language/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLanguage(string id, BELanguageViewModel ttsLanguage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await ttsLanguage.SaveModelAsync().ConfigureAwait(false); //_repo.EditModelAsync(ttsLanguage.ParseModel());
                    if (result.IsSucceed)
                    {
                        GlobalLanguageService.Instance.Refresh();
                    }
                    else
                    {
                        if (result.Exception != null)
                        {
                            ModelState.AddModelError(string.Empty, result.Exception?.Message);
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BELanguageViewModel.Repository.CheckIsExists(c => c.Specificulture == ttsLanguage.Specificulture))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Languages");
            }
            return View(ttsLanguage);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteLanguage(string id)
        {
            var result = await BELanguageViewModel.Repository.RemoveModelAsync(m => m.Keyword == id && m.Specificulture == CurrentLanguage).ConfigureAwait(false);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return RedirectToAction("Languages");
        }

        #endregion Languages
    }
}
