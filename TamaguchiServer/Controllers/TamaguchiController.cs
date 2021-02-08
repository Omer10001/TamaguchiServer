using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    Player p = context.Players.Where(pl => pl.PlayerId == pDto.PlayerId).FirstOrDefault();
                    p.CurrentPet.DoExersice(ex);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                }
                else
                    Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }

        [Route("AddAnimal")]
        [HttpPost]

        public void AddAnimal([FromBody] PetDTO pDTO, [FromBody] int playerID)
        {
            
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            
            
            Pet newAnimal = context.Pets.Where(x => x.PetId == pDTO.PetId).FirstOrDefault();
            List<PetDTO> petListDTO = new List<PetDTO>();

            


        }


    }
   



}
