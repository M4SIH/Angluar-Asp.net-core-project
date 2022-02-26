using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Database;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersControllers : Controller
    {
        private readonly CliDB _db;

        public UsersControllers(CliDB db)
        {
            _db = db;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok(new
                {
                    Message="Ok"
                });
            }
            catch(Exception exception)
            {
                var message=exception.Message;
                if (exception.InnerException.Message.Contains("Cannot insert duplicate key in object 'dbo.Accounts'"))
                {
                    message="یوزر اشتباه است یا قبلا وارد شده است";
                }
                return BadRequest(new
                {
                  Message=exception.InnerException.Message
                });
            }

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
            var fullname="";
            // var Username="";
            try
            {
                fullname=request.Filter.GetValue("fullname").ToString();  
                // Username=request.Filter.GetValue("accountUsername").ToString();  
            }
            catch
            {

            }
            var result= _db
                .Users
                .Where(p=> fullname==null || fullname=="" || p.Fullname.Contains(fullname));
                // .Where(p=> Username==null || Username=="" || p.AccountUsername.Contains(Username));
            var count=result.Count();
            var data=result
                .Skip(page*pageSize)
                .Take(pageSize)
                .Select(u=> new UserDTO
                {
                  AccountUsername=u.AccountUsername,
                  Fullname=u.Fullname  
                })
                .ToList();
            return new 
            {
                Data=data,
                Count=count
            };
        }


        [HttpPost("create")]
        public ActionResult Create (User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok();
        }


        [HttpGet("get/{id}")]
        public ActionResult<User> Get(string id)
        {
            return _db
                .Users
                .Include(m=>m.Account)
                .Where(m=>m.AccountUsername==id)
                .FirstOrDefault();
        }


        [HttpPost("update/{id}")]
        public ActionResult Update(User user, string id)
        {
            var dbUser=_db.Users.FirstOrDefault(m=> m.AccountUsername==id);
            if (dbUser!=null)
            {
                //mapping , مسِله دارد 
                dbUser.Fullname=user.Fullname;
                dbUser.AccountUsername=user.AccountUsername;
                _db.SaveChanges();
                return Ok();    
            }
            return NotFound();
        }


        [HttpGet("delete/{id}")]
        public ActionResult Delete(string id)
        {
            var dbUser=_db.Users.FirstOrDefault(m=> m.AccountUsername==id);
            if (dbUser!=null)
            {
                // _db.Users.Remove(dbUser);
                _db.Entry(dbUser).State=EntityState.Deleted;
                _db.SaveChanges();
                return Ok();    
            }
            return NotFound();
        }
        public static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
        [HttpGet("make/{count}")]
        public ActionResult Make(int count)
        {
            var fakeFirstname=new string[]{"ali","mohammad","sanaz","mohsen","amir","alireza","mahsa","ainza","sara","parisa"};
            var fakeLastname=new string[]{"agha miri", "rezae","majidi","soltani","karimi","hemati","esfahani","najafi","askari","vaziri"};
            var rg=new Random();
            
            for (int i = 0; i < count; i++)
            {
                var fakeusername=RandomString(5);
                var user=new User
                {
                    Fullname=fakeFirstname[rg.Next(fakeFirstname.Length)]+" "+fakeLastname[rg.Next(fakeLastname.Length)],
                    AccountUsername=fakeusername.ToString(),
                    Account=new Account
                    {
                        Password="123",
                        Username=fakeusername.ToString()
                    }
                };
                try
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();                   
                }
                catch
                {
                    i--;  
                }
            }
            return Ok();
        }

    }
}