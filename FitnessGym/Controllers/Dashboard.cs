using FitnessGym.Data;
using FitnessGym.Models;
using FitnessGym.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessGym.Controllers
{
    [Authorize(Roles="Admin")]
    public class Dashboard : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        public Dashboard( ApplicationDbContext dbContext , UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;

        }
        // GET: Dashboard
        public async Task<ActionResult> Index()
        {
            DashboardVM dashboard = new DashboardVM()
            {
                Trainees = _userManager.GetUsersInRoleAsync("Trainee").Result.ToList(),
                Programs = _dbContext.Programs.Include(p=>p.Trainees).ToList(),
                Subscriptions = _dbContext.Subscriptions.Include(s => s.Trainees).ToList()
            };
            return View(dashboard);
        }
    }
}
