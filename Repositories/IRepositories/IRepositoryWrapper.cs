namespace FitnessWeb_API.Repositories.IRepositories
{
    public interface IRepositoryWrapper
    {
         CompetitionRepository Competition { get; }
         void Save();
    }
}