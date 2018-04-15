// Licensed to the Halcyon Core Foundation under one or more agreements.
// The Halcyon Core Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace Halcyon.Cms.Lib.Models.Account
{
    public partial class AspNetUserLogins
    {
        [Key]
        public string Id { get; set; }

        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ApplicationUserId { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public AspNetUsers ApplicationUser { get; set; }
        public AspNetUsers User { get; set; }
    }
}
