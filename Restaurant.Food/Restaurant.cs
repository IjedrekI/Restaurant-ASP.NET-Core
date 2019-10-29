using System.ComponentModel.DataAnnotations;

namespace Restaurant.Food
{

    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, StringLength(155)]
        public string Location { get; set; }
        public CusineType Cusine { get; set; }
    }
}
