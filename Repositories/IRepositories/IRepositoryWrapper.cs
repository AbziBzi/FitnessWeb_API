namespace FitnessWeb_API.Repositories.IRepositories
{
    public interface IRepositoryWrapper
    {
         ICompetitionRepository Competition { get; }
         void Save();
    }
}