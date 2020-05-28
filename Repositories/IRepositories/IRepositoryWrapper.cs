namespace FitnessWeb_API.Repositories.IRepositories
{
    public interface IRepositoryWrapper
    {
         CompetitionRepository Competition { get; }
         UserRepository User { get; }
         CompetitorRepository Competitor { get; }

         SportProgramRepository SportProgram { get; }
         void Save();
    }
}