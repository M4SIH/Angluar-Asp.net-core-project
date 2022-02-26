using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Database;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/shop")]
    public class ShopController : Controller
    {
        private readonly CliDB _db;
        public ShopController(CliDB db)
        {
           _db = db; 
        }
        [HttpGet("courseList")]
        public ActionResult<List<CourseDTO>> CourseList()
        {
            var subscribes=new List<int>(); 

            if(User.Identity.IsAuthenticated)
            {
                var username=User.Claims.Where(c=>c.Type=="id").FirstOrDefault().Value;
                subscribes=_db
                    .Subscribes
                    .Include(s=>s.User)
                    .Include(s=>s.Course)
                    .Where(m=>m.User.AccountUsername==username)
                    .Select(s=>s.Course.Id)
                    .ToList();
            }
            return _db
                .Courses
                .OrderByDescending(m=> m.Id)
                .Select(c=>new CourseDTO
                {
                    Description=c.Description,
                    Title=c.Title,
                    CanSubscribe=!subscribes.Contains(c.Id),
                    Id=c.Id
                })
                .ToList();
        }
        // [HttpGet("courseList")]   ==>در تیم های حرفه ای به این شکل مینویسن
        // public ActionResult<List<Course>> CourseList() =>
        //     _db.Courses.OrderByDescending(m=> m.Id).ToList();

        [HttpPost("subscribe/{id}")]
        [Authorize]
        public ActionResult Subscribe(int id)
        {
            var course=_db.Courses.FirstOrDefault(m=>m.Id==id);
            if(course==null)
            {
                return NotFound();
            }
            var username=User.Claims.Where(c=>c.Type=="id").FirstOrDefault().Value; 
            var account=_db.Accounts
                .Include(m=>m.User)
                .Where(m=>m.Username==username)
                .FirstOrDefault();
            if(account==null || account.User==null)
            {   
                return Unauthorized();
            }
            var subscribe=new Subscribe
            {
                Course=course,
                User=account.User,
                IsActive=true,
                SubscribeTime=DateTime.Now
            };
            _db.Subscribes.Add(subscribe);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("get/{id}")]
        public ActionResult<Course> Get(int id)
        {
            return _db
                .Courses
                .Where(m=> m.Id==id)
                .FirstOrDefault();
        }


    }
}