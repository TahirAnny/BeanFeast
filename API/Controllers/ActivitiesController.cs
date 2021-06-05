using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public ActivitiesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _dbContext.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //activites/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _dbContext.Activities.FindAsync(id);
        }
    }
}