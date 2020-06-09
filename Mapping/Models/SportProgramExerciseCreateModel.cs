namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramExerciseCreateModel
    {
        public int? Setai { get; set; }
        public int? Kartojimai { get; set; }
        public int FkSportoProgramaId { get; set; }
        public int FkPratimasId { get; set; }
        
    }
}