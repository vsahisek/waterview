using System.ComponentModel.DataAnnotations;

namespace waterview.Data.Model
{
    public class Value
    {
        [Display(Name = "Number")]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public int WaterValue { get; set; }
        [Required]
        public int StationId { get; set; }
        //public virtual Station Station { get; set; } // StationID = Id u Stations(include)
        public Station? Station { get; set; }
    }
}
