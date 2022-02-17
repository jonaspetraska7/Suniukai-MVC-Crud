using System.ComponentModel.DataAnnotations;

namespace Suniukai_MVC_Paskaita.Models
{
    public class Kaciukas
    {
        [Key]
        public int Id { get; set; }
        public string? Vardas { get; set; }
        public string? Nuotrauka { get; set; }
        public string? Aprasymas { get; set; }
    }
}
