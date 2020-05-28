using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class CompetitionRepository
    {
        private AppDbContext _repository;
        public CompetitionRepository(AppDbContext repositoryContext)
        { 
            _repository = repositoryContext;
        }

        /// <summary>
        /// Finds all Competitions in DB
        /// </summary>
        /// <returns>List of all competitions</returns>
        public IQueryable<Varzybos> GetAllCompetitions()
        {
                return _repository.Set<Varzybos>()
                .Include(o => o.FkNaudotojas)       // Includes competition owner
                .Include(o => o.VarzybuDalyvis)     // Includes competition participant
                .ThenInclude(o => o.FkNaudotojas)   // same as above
                .AsNoTracking();
        }

        /// <summary>
        /// Finds competition by conditions - in most cases by ID
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>One or more competitions</returns>
        public IQueryable<Varzybos> GetCompetition(Expression<Func<Varzybos, bool>> expression)
        {
            return _repository.Set<Varzybos>().Where(expression)
                .Include(o => o.FkNaudotojas)       // Includes competition owner
                .Include(o => o.VarzybuDalyvis)     // Includes competition participant
                .ThenInclude(o => o.FkNaudotojas)   // same as above
                .AsNoTracking();
        }

        /// <summary>
        /// Creats new Competition and adds it to DB
        /// </summary>
        /// <param name="entity">Competition DTO</param>
        /// <returns>Competition</returns>
        public Varzybos CreateCompetition(CompetitionCreateModel entity)
        {
            var competition = _repository.Mapper.Map<CompetitionCreateModel, Varzybos>(entity);
            if (competition.FkNaudotojasId == default)
                competition.FkNaudotojasId = 1;
            _repository.Set<Varzybos>().Add(competition);
            _repository.SaveChanges();

            return competition;
        }

        public Varzybos UpdateCompetition(CompetitionUpdateModel entity, int id)
        {
            var foundCompetition = _repository.Set<Varzybos>().
                FirstOrDefault(o => o.IdVarzybos.Equals(id));

            if(foundCompetition == null)
                return null;

            foundCompetition.PrasidejimoData = entity.PrasidejimoData;
            foundCompetition.Pavadinimas = entity.Pavadinimas;
            foundCompetition.Aprasas = entity.Aprasas;
            foundCompetition.PabaigosData = entity.PabaigosData;
            foundCompetition.Vieta = entity.Vieta;
            
            _repository.SaveChanges();
            return foundCompetition;
        }

        public void DeleteCompetition(Varzybos entity)
        {   
            _repository.Set<Varzybos>().Remove(entity);
        }
    }
}