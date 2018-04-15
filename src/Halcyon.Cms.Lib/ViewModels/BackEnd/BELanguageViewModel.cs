// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Cms.Lib.Services;
using Halcyon.Domain.Core.Models;
using Halcyon.Domain.Core.ViewModels;
using Halcyon.Domain.Data.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Halcyon.Cms.Lib.ViewModels.BackEnd
{
    public class BELanguageViewModel :
        ViewModelBase
        <SiocCmsContext, SiocLanguage, BELanguageViewModel>
    {
        [Required]
        public string Keyword { get; set; }

        public string Category { get; set; }
        public string Value { get; set; }
        public SWCmsConstants.DataType DataType { get; set; }
        public string Description { get; set; }

        public BELanguageViewModel() : base()
        {
        }

        public BELanguageViewModel(
            SiocLanguage model
            , SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = true;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
        }

        public override RepositoryResponse<BELanguageViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override async Task<RepositoryResponse<BELanguageViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                GlobalLanguageService.Instance.Refresh();
            }
            return result;
        }

        public override RepositoryResponse<List<BELanguageViewModel>> Clone(SiocLanguage model, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            model.Value = Model.Keyword;
            return base.Clone(model, cloneCultures, _context, _transaction);
        }

        public override Task<RepositoryResponse<List<BELanguageViewModel>>> CloneAsync(SiocLanguage model, List<SupportedCulture> cloneCultures, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            model.Value = Model.Keyword;
            return base.CloneAsync(model, cloneCultures, _context, _transaction);
        }

        #endregion Overrides
    }
}
