using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations;
using Registery.Domain.Entities;
using Registery.Models.Account;

namespace Registery.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IMediator mediator, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var organizations = await _mediator.Send(new GetOrganizationsQuery(), CancellationToken.None);
            List<SelectListItem> organizationsSelectList = organizations
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                ).Distinct().ToList();
            ViewBag.organizationsSelectList = organizationsSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = _mapper.Map<User>(registerVM);
            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(registerVM);
        }


        public IActionResult Login(string returnUrl = null!)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(new LoginVM { ReturnUrl = returnUrl });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index), "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин и (или) пароль");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
