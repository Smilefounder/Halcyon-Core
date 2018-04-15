// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Halcyon.Api.Controllers;
using Halcyon.Cms.Lib;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Cms.Lib.ViewModels.BackEnd;
using Halcyon.Cms.Lib.ViewModels.Navigation;
using Halcyon.Domain.Core.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/{culture}/nav")]
    public class ApiNavigationController :
        BaseApiController
    {
        public ApiNavigationController(IHostingEnvironment env)
        {
        }

        #region Post

        // GET api/medias

        [HttpPost, HttpOptions]
        [Route("list/related-product")]
        public async Task<RepositoryResponse<PaginationModel<NavRelatedProductViewModel>>> GetList(RequestPaging request)
        {
            if (string.IsNullOrEmpty(request.Keyword))
            {
                var data = await NavRelatedProductViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

                return data;
            }
            else
            {
                Expression<Func<SiocRelatedProduct, bool>> predicate = model =>
                    model.Specificulture == _lang
                    && (string.IsNullOrWhiteSpace(request.Keyword));
                var data = await NavRelatedProductViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

                return data;
            }
        }

        
        #endregion Post

        
    }
}
