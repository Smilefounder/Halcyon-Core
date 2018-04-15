// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace Halcyon.Cms.Lib.Models.Cms
{
    public partial class SiocCategoryProduct
    {
        public string ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Specificulture { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public SiocCategory SiocCategory { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
