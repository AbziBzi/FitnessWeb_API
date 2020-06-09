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
            var foundExercise = _repository.Set<AtliekamasPratimas>()
                .Where(o => o.IdAtliekamasPratimas.Equals(id))
                .Include(o => o.FkPratimas)
                .Include(o => o.FkTreneris)
                    .ThenInclude(o => o.IdNaudotojasNavigation)
                .FirstOrDefault();
            if (foundExercise == null)
                return null;
            foundExercise.FkPratimasId = (entity.FkPratimasId != null) ? entity.FkPratimasId : foundExercise.FkPratimasId;
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

            return exercise;
        }

        public PerformedExerciseRatingGetModel CheckRating(int id)
        {
            var foundExercise = GetExercise(o => o.IdAtliekamasPratimas.Equals(id));
            if (foundExercise.FirstOrDefault() == null)
                return null;
            var exercise = foundExercise.Include(o => o.FkTreneris)
                    .ThenInclude(o => o.IdNaudotojasNavigation)
                .FirstOrDefault();
            if (exercise.Ivertinimas == null)
                return null;
            return _repository.Mapper.Map<AtliekamasPratimas, PerformedExerciseRatingGetModel>(exercise);
        }

        public AtliekamasPratimas InsertRating(int id, PerformedExerciseRatingCreateModel rating)
        {
            var exercise = _repository.Set<AtliekamasPratimas>()
                .FirstOrDefault(o => o.IdAtliekamasPratimas.Equals(id));
            if (exercise == null)
                return null;
            exercise.Kiekis = (rating.Kiekis != null) ? rating.Kiekis : exercise.Kiekis;

            exercise.Ivertinimas = (rating.Ivertinimas != null) ? rating.Ivertinimas : exercise.Ivertinimas;
            exercise.IvertinimoData = (rating.Ivertinimas != null) ? DateTime.Now : exercise.IvertinimoData;
            exercise.FkTrenerisId = (rating.FkTrenerisId != null) ? rating.FkTrenerisId : exercise.FkTrenerisId;

            _repository.SaveChanges();
            return exercise;
        }

        public AtliekamasPratimas UpdateRating(int id, PerformedExerciseRatingCreateModel rating)
        {
            var exercise = _repository.Set<AtliekamasPratimas>()
                .FirstOrDefault(o => o.IdAtliekamasPratimas.Equals(id));
            if (exercise == null)
                return null;

            exercise.Ivertinimas = (rating.Ivertinimas != null) ? rating.Ivertinimas : exercise.Ivertinimas;
            exercise.IvertinimoData = (rating.Ivertinimas != null) ? DateTime.Now : exercise.IvertinimoData;
            exercise.FkTrenerisId = (rating.FkTrenerisId != null) ? rating.FkTrenerisId : exercise.FkTrenerisId;

            _repository.SaveChanges();
            return exercise;
        }

        public AtliekamasPratimas DeleteRating(int id)
        {
            var exercise = _repository.Set<AtliekamasPratimas>()
                .FirstOrDefault(o => o.IdAtliekamasPratimas.Equals(id));
            if (exercise == null)
                return null;
            exercise.Kiekis = 0;
            exercise.Ivertinimas = null;
            exercise.IvertinimoData = null;
            exercise.FkTrenerisId = null;

            _repository.SaveChanges();
            return exercise;
        }
    }
}