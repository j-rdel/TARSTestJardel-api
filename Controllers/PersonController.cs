using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARSTestJardel.Models;
using TARSTestJardel.Data;

namespace TARSTestJardel.Controllers
{
    
    [ApiController]
    [Route("person")]

    public class PersonController : ControllerBase
    {
       
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Person>>> GetList([FromServices] DataContext context)
        {
            var listPerson = await context.Persons.ToListAsync();
            return listPerson;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Person>> Create([FromServices] DataContext context, [FromBody]Person model)
        {
            if (ModelState.IsValid){
                context.Persons.Add(model);
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
        public async Task<ActionResult<Person>> Remove([FromServices] DataContext context, [FromBody]Person model, int id)
        {
            var person = await context.Persons.FindAsync(id);

            if (person == null){
               return NotFound();
            }

            context.Persons.Remove(person);
            await context.SaveChangesAsync();
            return Content("Person successfully deleted!");    
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Person>> GetPerson([FromServices] DataContext context, int id)
        {
            var person = await context.Persons.FindAsync(id);

            if (person == null){
               return NotFound();
            }

            return person;    
        }


        [HttpPatch]
        [Route("{id}")]

        public async Task<ActionResult<Person>> Update([FromServices] DataContext context, [FromBody]Person model, int id)
        { 
            var entity = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);

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
        }

    }
}