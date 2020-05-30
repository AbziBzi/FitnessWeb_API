using System;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class PerformingExercisesRepository
    {
        private readonly AppDbContext _repository;

        public PerformingExercisesRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<AtliekamasPratimas> GetCompletedExercisesForUser(int userId)
        {
            return _repository.Set<AtliekamasPratimas>()
                .Where(o => o.FkSportininkasId.Equals(userId) && o.VaizdoIrasasUrl != null)
                .Include(o => o.FkPratimas)
                .Include(o => o.FkTreneris)
                    .ThenInclude(o => o.IdNaudotojasNavigation)
                .AsNoTracking();
        }

        public IQueryable<AtliekamasPratimas> GetExercise(Expression<Func<AtliekamasPratimas, bool>> expression)
        {
            return _repository.Set<AtliekamasPratimas>().Where(expression)
                .Include(o => o.FkPratimas)
                .Include(o => o.FkTreneris)
                    .ThenInclude(o => o.IdNaudotojasNavigation)
                .AsNoTracking();
        }

        public AtliekamasPratimas UpdateExercise(int id, PerformingExerciseUpdateModel entity)
        {
            var foundExercise = GetExercise(o => o.IdAtliekamasPratimas.Equals(id)).FirstOrDefault();
            if (foundExercise == null)
                return null;
            
            foundExercise.VaizdoIrasasUrl = (entity.VaizdoIrasasUrl != null) ? entity.VaizdoIrasasUrl : foundExercise.VaizdoIrasasUrl;
            _repository.SaveChanges();
            return foundExercise;
        }

        public void DeleteExercise(AtliekamasPratimas entity)
        {
            _repository.Set<AtliekamasPratimas>().Remove(entity);
            _repository.SaveChanges();
        }

        public IQueryable<AtliekamasPratimas> GetExercises()
        {
            return _repository.Set<AtliekamasPratimas>()
                .Where(O => O.Ivertinimas == null && O.VaizdoIrasasUrl != null)
                .Include(o => o.FkPratimas)
                .Include(o => o.FkTreneris)
                    .ThenInclude(o => o.IdNaudotojasNavigation)
                .AsNoTracking();
        }

        public AtliekamasPratimas CreatePerformingExercise(PerformingExerciseCreateModel entity)
        {
            var exercise = _repository.Mapper.Map<PerformingExerciseCreateModel, AtliekamasPratimas>(entity);
            exercise.FkSportininkasId = 1;
            int includedExerciseId = entity.FkPratimasId;
            var includedExercise = _repository.Set<Pratimas>().Where(o => o.IdPratimas.Equals(includedExerciseId)).FirstOrDefault();
            if (includedExercise == null)
                return null;
            _repository.Set<AtliekamasPratimas>().Add(exercise);
            _repository.SaveChanges();

            return GetExercise(o => o.IdAtliekamasPratimas.Equals(exercise.IdAtliekamasPratimas)).FirstOrDefault();
        }
    }
}