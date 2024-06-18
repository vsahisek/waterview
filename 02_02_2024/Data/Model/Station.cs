using System.ComponentModel.DataAnnotations;

namespace waterview.Data.Model
{
    public class Station
    {
        internal object Values;

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1,100)]
        public int FloodLevel { get; set; }
        [Required]
        [Range(1, 100)]
        public int DroughtLevel { get; set; }
        [Required]
        [Range(60, 7200)]
        public int TimeOutInMinutes { get; set; }

    }
}
