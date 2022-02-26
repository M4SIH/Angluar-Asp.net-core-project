using System;
using System.Linq;
using Backend.Database;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/managers")]
    public class ManagersController : Controller    
    {
        private readonly CliDB _db;
        public ManagersController(CliDB db)
        {
            _db=db;
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
            try
            {
                fullname=request.Filter.GetValue("fullname").ToString();    
            }
            catch
            {

            }
            var result= _db
                .Managers
                .Where(p=> fullname==null || fullname=="" || p.Fullname.Contains(fullname));

            var count=result.Count();
            var data=result
                .Skip(page*pageSize)
                .Take(pageSize)
                .Select(u=> new ManagerDTO
                {
                  AccountUsername=u.AccountUsername,
                  Fullname=u.Fullname,
                  Type=u.Type 
                })
                .ToList();
            return new 
            {
                Data=data,
                Count=count
            };
        }
    }
}