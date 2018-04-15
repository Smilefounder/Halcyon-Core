// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Domain.Data.ViewModels;

namespace Halcyon.Cms.Lib.ViewModels
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Halcyon.Domain.Data.ViewModels.ViewModelBase{Halcyon.Cms.Lib.Models.SiocCmsContext, Halcyon.Cms.Lib.Models.SiocCategoryCategory, Halcyon.Cms.Lib.ViewModels.CategoryCategoryViewModel}" />
    public class CategoryCategoryViewModel : ViewModelBase<SiocCmsContext, SiocCategoryCategory, CategoryCategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCategoryViewModel"/> class.
        /// </summary>
        public CategoryCategoryViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCategoryViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="_context"></param>
        /// <param name="_transaction"></param>
        public CategoryCategoryViewModel(SiocCategoryCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is actived; otherwise, <c>false</c>.
        /// </value>
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
