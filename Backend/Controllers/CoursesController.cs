using System;
using System.Linq;
using Backend.Database;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : Controller
    {
        private readonly CliDB _db;

        public CoursesController(CliDB db)
        {
            _db = db;
        }

        [HttpPost("list")]
        public ActionResult<Object> List(ListRequest request)
        {
            var pageSize=10;
            var page=0;
            if (request!=null)
            {
                page=request.page;
                pageSize=request.pageSize;
            }
            if(pageSize>100) pageSize=10;
            if(pageSize<10) pageSize=10;
            var title="";
            try
            {
                title=request.Filter.GetValue("title").ToString();  
            }
            catch
            {

            }
            var result= _db
                .Courses
                .Where(p=> title==null || title=="" || p.Title.Contains(title));
            var count=result.Count();
            var data=result
                .Skip(page*pageSize)
                .Take(pageSize)
                .Select(u=> new CourseDTO
                {
                  Title=u.Title,
                  PracticalTime=u.PracticalTime,
                  TheoryTime=u.TheoryTime,
                  Description=u.Description  
                })
                .ToList();
            return new 
            {
                Data=data,
                Count=count
            };
        }


        [HttpPost("create")]
        public ActionResult Create (Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return Ok();
        }


        [HttpGet("get/{id}")]
        public ActionResult<Course> Get(int id)
        {
            return _db
                .Courses
                .Where(m=>m.Id==id)
                .FirstOrDefault();
        }


        [HttpPost("update/{id}")]
        public ActionResult Update(Course course, int id)
        {
            var dbCourse=_db.Courses.FirstOrDefault(m=> m.Id==id);
            if (dbCourse!=null)
            {
                //mapping , مسِله دارد 
                dbCourse.Title=course.Title;
                dbCourse.Description=course.Description;
                dbCourse.PracticalTime=course.PracticalTime;
                dbCourse.TheoryTime=course.TheoryTime;
                _db.SaveChanges();
                return Ok();    
            }
            return NotFound();
        }


        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var dbCourse=_db.Courses.FirstOrDefault(m=> m.Id==id);
            if (dbCourse!=null)
            {
                // _db.Users.Remove(dbUser);
                _db.Entry(dbCourse).State=EntityState.Deleted;
                _db.SaveChanges();
                return Ok();    
            }
            return NotFound();
        }

    }
}