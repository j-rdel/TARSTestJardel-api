using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARSTestJardel.Models;
using TARSTestJardel.Data;

namespace TARSTestJardel.Controllers
{
    [ApiController]
    [Route("peoples")]

    public class PeopleController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<People>>> List([FromServices] DataContext context)
        {
            var peoples = await context.Peoples.ToListAsync();
            return peoples;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<People>> Create([FromServices] DataContext context, [FromBody]People model)
        {
            if (ModelState.IsValid){
                context.Peoples.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<People>> Remove([FromServices] DataContext context, [FromBody]People model, int id)
        {
            var people = await context.Peoples.FindAsync(id);

            if (people == null){
               return NotFound();
            }

            context.Peoples.Remove(people);
            await context.SaveChangesAsync();
            return NoContent();    
        }


        [HttpPatch]
        [Route("{id}")]

        public async Task<ActionResult<People>> Update([FromServices] DataContext context, [FromBody]People model, int id)
        { 
            var entity = await context.Peoples.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null) {
                if(ModelState.IsValid){
                    entity.Name = model.Name;
                    entity.Age = model.Age;
                    entity.Career = model.Career;
                    entity.PhotoURL = model.PhotoURL;
                    await context.SaveChangesAsync();
                    return entity;
                } 
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else {
                return NotFound();
            }
            // await context.SaveChangesAsync();
            // return model;
            // if (ModelState.IsValid){
            //     people = model;
            //     await context.SaveChangesAsync();
            //     return people;
            // }
            // else
            // {
            //     return BadRequest(ModelState);
            // }
        }

    }
}