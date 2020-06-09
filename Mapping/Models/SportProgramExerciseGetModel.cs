using FitnessWeb_API.Models;

namespace FitnessWeb_API.Mapping.Models
{
    public class SportProgramExerciseGetModel
    {
        public int? Setai { get; set; }
        public int? Kartojimai { get; set; }
        public int IdSportoProgramosPratimas { get; set; }

        public virtual ExerciseGetModel FkPratimas { get; set; }
    }
}