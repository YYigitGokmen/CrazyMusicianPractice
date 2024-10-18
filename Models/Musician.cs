using System.ComponentModel.DataAnnotations;

namespace CrazyMusiciansPractice.Models
{
    public class Musician
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Profession { get; set; }

        [Required]
        public string FunnyFeature { get; set; }
    }
}
