// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Domain.Data.ViewModels;

namespace Halcyon.Cms.Lib.ViewModels.Info
{
    public class InfoArticleModuleViewModel
       : ViewModelBase<SiocCmsContext, SiocArticleModule, InfoArticleModuleViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        [JsonProperty("moduleId")]
        public int ModuleId { get; set; }

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Models

        #endregion Properties

        #region Contructors

        public InfoArticleModuleViewModel() : base()
        {
        }

        public InfoArticleModuleViewModel(SiocArticleModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}
