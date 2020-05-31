using System;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class SportProgramRepository
    {
        private AppDbContext _repository;

        public SportProgramRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<SportoPrograma> GetAllPrograms()
        {
            return _repository.Set<SportoPrograma>()
                              .Include(o => o.FkTreneris)
                                    .ThenInclude(o => o.IdNaudotojasNavigation)
                              .Include(o => o.SportoProgramosPratimas)
                                    .ThenInclude(o => o.FkPratimas)
                              .AsNoTracking();
        }

        public IQueryable<SportoPrograma> GetSportProgram(Expression<Func<SportoPrograma, bool>> expression)
        {
            return _repository.Set<SportoPrograma>().Where(expression)
                              .Include(o => o.FkTreneris)
                                    .ThenInclude(o => o.IdNaudotojasNavigation)
                              .Include(o => o.SportoProgramosPratimas)
                                    .ThenInclude(o => o.FkPratimas)
                              .AsNoTracking();
        }

        public IQueryable<SportoPrograma> GetAllTrainerPrograms(int id)
        {
            return _repository.Set<SportoPrograma>().Where(o => o.FkTrenerisId.Equals(id))
                              .Include(o => o.FkTreneris)
                                    .ThenInclude(o => o.IdNaudotojasNavigation)
                              .Include(o => o.SportoProgramosPratimas)
                                    .ThenInclude(o => o.FkPratimas)
                              .AsNoTracking();
        }

        public SportoPrograma InsertProgram(SportProgramCreateModel entity)
        {
            var program = _repository.Mapper.Map<SportProgramCreateModel, SportoPrograma>(entity);
            _repository.Set<SportoPrograma>().Add(program);
            _repository.SaveChanges();
            return program;
        }

        public SportoPrograma UpdateProgram(int id, SportProgramUpdateModel entity)
        {
            var program = _repository.Set<SportoPrograma>()
                .FirstOrDefault(o => o.IdSportoPrograma.Equals(id));
            if (program == null)
                return null;

            program.Pavadinimas = (entity.Pavadinimas != null) ? entity.Pavadinimas : program.Pavadinimas;
            program.Aprasas = (entity.Aprasas != null) ? entity.Aprasas : program.Aprasas;
            program.NuotraukosUrl = (entity.NuotraukosUrl != null) ? entity.NuotraukosUrl : program.NuotraukosUrl;
            if (entity.SportoProgramosPratimas != null)
            {
                foreach (var e in entity.SportoProgramosPratimas)
                {
                    var exercise = _repository.Mapper.Map<SportProgramExerciseUpdateModel, SportoProgramosPratimas>(e);
                    program.SportoProgramosPratimas.Where(c => c.IdSportoProgramosPratimas.Equals(exercise.IdSportoProgramosPratimas))
                        .ToList()
                        .Select(c => {
                            c.FkPratimasId = exercise.FkPratimasId;
                            c.FkSportoProgramaId = exercise.FkSportoProgramaId;
                            c.Setai = (exercise.Setai != null) ? exercise.Setai : c.Setai;
                            c.Kartojimai = (exercise.Kartojimai != null) ? exercise.Kartojimai : c.Kartojimai;
                            return c;
                        });
                }
            }
            _repository.SaveChanges();
            return program;
        }

        public SportoPrograma DeleteProgram(int id)
        {
            var program = GetSportProgram(o => o.IdSportoPrograma.Equals(id)).FirstOrDefault();
            if (program == null)
                return null;
            _repository.Set<SportoPrograma>().Remove(program);
            _repository.SaveChanges();
            return program;
        }
    }
}