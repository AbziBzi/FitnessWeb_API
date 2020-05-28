namespace FitnessWeb_API.Mapping.Models
{
    public class ExerciseGetModel
    {
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int? Verte { get; set; }
        public int IdPratimas { get; set; }
    }
}