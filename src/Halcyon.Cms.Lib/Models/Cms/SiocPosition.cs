﻿// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Halcyon.Cms.Lib.Models.Cms
{
    public partial class SiocPosition
    {
        public SiocPosition()
        {
            SiocCategoryPosition = new HashSet<SiocCategoryPosition>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

        public ICollection<SiocCategoryPosition> SiocCategoryPosition { get; set; }
    }
}
