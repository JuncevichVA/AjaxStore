using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace laba_1.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public byte[] AvatarImage { get; set; }
        public string ImageMimeType { get; set; }
    }
}
