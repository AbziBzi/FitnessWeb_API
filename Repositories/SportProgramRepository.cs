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

            if (entity.SportoProgramosPratimas != null || !entity.SportoProgramosPratimas.Any())
            {
                foreach (var exe in entity.SportoProgramosPratimas)
                {
                    var newExercise = UpdateSportProgramExercise(exe.IdSportoProgramosPratimas, exe);
                }
            }

            _repository.SaveChanges();
            return program;
        }

        public SportoProgramosPratimas UpdateSportProgramExercise(int id, SportProgramExerciseUpdateModel exercise)
        {
            var exe = _repository.Set<SportoProgramosPratimas>()
                .FirstOrDefault(o => o.IdSportoProgramosPratimas.Equals(id));
            if (exe == null)
                return null;
            exe.Setai = (exercise.Setai != null) ? exercise.Setai : exe.Setai;
            exe.Kartojimai = (exercise.Kartojimai != null) ? exercise.Kartojimai : exe.Kartojimai;
            exe.FkSportoProgramaId = (exercise.FkSportoProgramaId != null) ? exercise.FkSportoProgramaId : exe.FkSportoProgramaId;
            exe.FkPratimasId = (exercise.FkPratimasId != null) ? exercise.FkPratimasId : exe.FkPratimasId;
            _repository.SaveChanges();
            return exe;
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