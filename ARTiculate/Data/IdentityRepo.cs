using ARTiculate.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ARTiculate.Data
{
     
    public class IdentityRepo : Controller
    {
        private readonly UserManager<ARTiculateUser> _userManager;

        public IdentityRepo(UserManager<ARTiculateUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetCurrentUserMail()
        {
            ARTiculateUser user = await GetCurrentUserAsync();
            return user.Email;
        }

        private Task<ARTiculateUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
