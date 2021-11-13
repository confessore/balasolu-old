using balasolu.models;
using balasolu.models.enums;
using balasolu.web.models;
using balasolu.web.models.abstractions;
using balasolu.web.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static AspNet.Security.OAuth.Discord.DiscordAuthenticationConstants;

namespace balasolu.web.pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        readonly SignInManager<User> _signInManager;
        readonly UserManager<User> _userManager;

        public LoginModel(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var eas = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var provider = eas.FirstOrDefault()?.Name;
            var redirectUrl = Url.Page("/login", pageHandler: "callback");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnPostAsync() =>
            await OnGetAsync();

        public async Task<IActionResult> OnGetCallbackAsync()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return Redirect("/error");
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.IsLockedOut)
                return Redirect("/lockout");
            if (signInResult.Succeeded)
            {
                var id = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var username = info.Principal.FindFirstValue(ClaimTypes.Name);
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var discriminator = info.Principal.FindFirstValue(Claims.Discriminator);
                var avatar = info.Principal.FindFirstValue(Claims.AvatarHash);
                var verified = info.Principal.FindFirstValue("urn:discord:user:verified");
                var account = new DiscordAccount()
                {
                    AccountType = AccountType.Discord,
                    Id = Convert.ToUInt64(id),
                    Username = username,
                    Discriminator = Convert.ToInt32(discriminator),
                    Email = email,
                    Avatar = avatar,
                    Verified = Convert.ToBoolean(verified)
                };
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                user.UserName = username;
                user.Email = email;
                user.Account = account;
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                await _userManager.UpdateAsync(user);
                return Redirect("/");
            }
            else
            {
                var id = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var username = info.Principal.FindFirstValue(ClaimTypes.Name);
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var discriminator = info.Principal.FindFirstValue(Claims.Discriminator);
                var avatar = info.Principal.FindFirstValue(Claims.AvatarHash);
                var verified = info.Principal.FindFirstValue("urn:discord:user:verified");
                if (ModelState.IsValid)
                {
                    var account = new DiscordAccount()
                    {
                        AccountType = AccountType.Discord,
                        Id = Convert.ToUInt64(id),
                        Username = username,
                        Discriminator = Convert.ToInt32(discriminator),
                        Email = email,
                        Avatar = avatar,
                        Verified = Convert.ToBoolean(verified)
                    };
                    var user = new DefaultUser { UserName = username, Email = email, Account = account };
                    var createResult = await _userManager.CreateAsync(user);
                    if (createResult.Succeeded)
                    {
                        createResult = await _userManager.AddLoginAsync(user, info);
                        if (createResult.Succeeded)
                        {
                            await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                            await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                            return Redirect("/");
                        }
                    }
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return Redirect("/");
            }
        }
    }
}
