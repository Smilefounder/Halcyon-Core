// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Halcyon.Cms.Lib.Models.Cms;
using Halcyon.Domain.Data.ViewModels;

namespace Halcyon.Cms.Lib.ViewModels.BackEnd
{
    public class BEParameterViewModel
        : ViewModelBase<SiocCmsContext, SiocParameter, BEParameterViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        #endregion Models

        #endregion Properties

        #region Contructors

        public BEParameterViewModel() : base()
        {
        }

        public BEParameterViewModel(SiocParameter model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion Contructors
    }
}
