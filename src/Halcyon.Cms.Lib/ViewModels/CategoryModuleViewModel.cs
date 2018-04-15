// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Domain.Data.ViewModels;

namespace Halcyon.Cms.Lib.ViewModels
{
    public class CategoryModuleViewModel
        : ViewModelBase<SiocCmsContext, SiocCategoryModule, CategoryModuleViewModel>
    {
        public CategoryModuleViewModel()
        {
        }

        public CategoryModuleViewModel(SiocCategoryModule model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        public int ModuleId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
