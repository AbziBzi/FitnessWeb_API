namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramExerciseUpdateModel
    {
        public string Pavadinimas { get; set; }
        public string Aprasas { get; set; }
        public string NuotraukosUrl { get; set; }
        public int IdSportoPrograma { get; set; }
        public int FkTrenerisId { get; set; }
        public int IdSportoProgramosPratimas { get; set; }

    }
}