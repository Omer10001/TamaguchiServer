using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TamaguchiBL.Models;
using TamaguchiServer.DataTransferObjects;

namespace TamaguchiServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {
        TamaguchiContext context;
        public TamaguchiController(TamaguchiContext context)
        {
            this.context = context;
        }
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "hello world";
        }
        [Route("GetExListByType")]
        [HttpGet]
        public List<ExerciseDTO> GetExByType([FromQuery] int typeID)
        {
            try
            {
                List<Exercise> exList = this.context.ExercisesByType(typeID);
                if (exList != null)
                {
                    List<ExerciseDTO> exListDto = new List<ExerciseDTO>();
                    foreach (Exercise ex in exList)
                    {
                        exListDto.Add(new ExerciseDTO(ex));
                    }
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return exListDto;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }

        }
        [Route("DoExercise")]     
        [HttpPost] 
        public void DoExercise([FromBody] ExerciseDTO exDTO)
        {
            try
            {
                PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
                //Check if user logged in!
                if (pDto != null)
                {
                    Exercise ex = context.Exercises.Where(x => x.ExerciseId == exDTO.ExerciseId).FirstOrDefault();
                    Player p = context.Players.Where(pl => pl.PlayerId == pDto.PlayerID).FirstOrDefault();
                    p.CurrentPet.DoExersice(ex);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                }
                else
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
        }
        [Route("Login")]
        [HttpPost]
        public PlayerDTO Login([FromBody] PlayerDTO login)
        {
            try
            {
                Player p = context.Login(login.Email, login.UserPassword);

                //Check user name and password
                if (p != null)
                {
                    PlayerDTO pDTO = new PlayerDTO(p);

                    HttpContext.Session.SetObject("player", pDTO);

                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return pDTO;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
        }
        [Route("SignUp")]
        [HttpPost]
        public void SignUp([FromBody] PlayerDTO p)
        {
            try
            {
                Player checkEmail = context.Players.Where(x => x.Email == p.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Conflict;
                    return;
                }
                context.CreateUser(p.FirstName, p.LastName, p.Email, p.Gender, p.BirthDate, p.UserName, p.UserPassword);
                HttpContext.Session.SetObject("player", p);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return;
            }
           catch(Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return;
            }

        }

        [Route("AddAnimal")]
        [HttpPost]

        public void AddAnimal([FromBody] PetDTO petDTO)
        {



            PlayerDTO playerDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (playerDTO != null)
            {

                this.context.CreateAnimal(petDTO.PetName, playerDTO.PlayerID);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;


            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return;

            }







            //public void AddAnimal([FromBody] PetDTO pDTO, [FromBody] int playerID)
            //{
            //    PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //    Pet newAnimal = context.Pets.Where(x => x.PetId == pDTO.PetId).FirstOrDefault();
            //    List<PetDTO> petListDTO = new List<PetDTO>();
            //}


        }

 }  }
