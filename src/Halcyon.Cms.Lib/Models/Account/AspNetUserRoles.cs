// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace Halcyon.Cms.Lib.Models.Account
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string ApplicationUserId { get; set; }

        public AspNetUsers ApplicationUser { get; set; }
        public AspNetRoles Role { get; set; }
        public AspNetUsers User { get; set; }
    }
}
