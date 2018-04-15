// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System;

namespace Halcyon.Cms.Lib.Models.Cms
{
    public partial class SiocRelatedProduct
    {
        public string SourceProductId { get; set; }
        public string RelatedProductId { get; set; }
        public string Specificulture { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }

        public SiocProduct S { get; set; }
        public SiocProduct SiocProduct { get; set; }
    }
}
