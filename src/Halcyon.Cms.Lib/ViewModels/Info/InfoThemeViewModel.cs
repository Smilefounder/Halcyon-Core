// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Common.Helper;
using Halcyon.Domain.Data.ViewModels;
using System;

namespace Halcyon.Cms.Lib.ViewModels.Info
{
    public class InfoThemeViewModel
       : ViewModelBase<SiocCmsContext, SiocTheme, InfoThemeViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("isActived")]
        public bool IsActived { get; set; }

        [JsonProperty("asset")]
        public IFormFile Asset { get; set; }// = new FileViewModel();

        [JsonProperty("assetFolder")]
        public string AssetFolder {
            get {
                return CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.FileFolder,
                    SWCmsConstants.Parameters.TemplatesAssetFolder,
                    Name });
            }
        }

        [JsonProperty("templateFolder")]
        public string TemplateFolder {
            get {
                return CommonHelper.GetFullPath(new string[] { SWCmsConstants.Parameters.TemplatesFolder, Name });
            }
        }

        #endregion Views

        #endregion Properties

        #region Contructors

        public InfoThemeViewModel()
            : base()
        {
        }

        public InfoThemeViewModel(SiocTheme model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}
