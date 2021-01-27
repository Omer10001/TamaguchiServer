using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {
        TamaguchiContext context;
        public TamaguchiController(TamaguchiContext context)
        {
            this.context = context;
        }
    }
    //[Route("test")]
    //[HttpGet]
    //public void Test()
    //{
        
    //}
        


}
