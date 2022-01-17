using System.ComponentModel.DataAnnotations;

namespace TARSTestJardel.Models 
{
    public class Person 
    {
        [Key]
        public int Id {get; set;}

        public string Name {get; set;}

        public int Age {get; set;}

        public string Career {get; set;}

        public string PhotoURL {get; set;}
    }
}