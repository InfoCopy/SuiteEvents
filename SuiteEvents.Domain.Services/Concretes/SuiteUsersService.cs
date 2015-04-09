using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SuiteEvents.Domain.Repositories;
using SuiteEvents.Domain.Resources.Exceptions;
using SuiteEvents.Domain.Services.Abstracts;
using SuiteEvents.Domain.Services.Dtos;
using SuiteEvents.Domain.ValidationRules;

namespace SuiteEvents.Domain.Services.Concretes
{
    public class SuiteUsersService : ISuiteEventsService<DtoSuiteUsers>
    {
        private readonly ISuiteEventsUnitOfWork _suiteEventsUnitOfWork;

        public SuiteUsersService(ISuiteEventsUnitOfWork suiteEventsUnitOfWork)
        {
            this._suiteEventsUnitOfWork = suiteEventsUnitOfWork;
        }

        public DtoSuiteUsers Create(Guid id)
        {
            return new DtoSuiteUsers
            {
                Id = id,
                Nome = "nome",
                Cognome = "cognome"
            };
        }

        public Task InsertAsync(DtoSuiteUsers entityToAdd)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DtoSuiteUsers entityToUpdate)
        {
            // Controllo Consistenza Dati
            // Ogni Layer è responsabile per la consistenza dei dati che riceve
            ChkDataIntegrity(entityToUpdate);

            //var currentUser = await this._suiteEventsUnitOfWork.SuiteUsersRepository.GetByIdAsync(entityToUpdate.Id);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DtoSuiteUsers> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DtoSuiteUsers>> GetAllAsync(int pageIndex, int pageSize, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DtoSuiteUsers>> QueryAsync(Expression<Func<DtoSuiteUsers, bool>> filter = null, 
            Func<IQueryable<DtoSuiteUsers>, IOrderedQueryable<DtoSuiteUsers>> orderBy = null, 
            string includeProperties = "")
        {
            throw new System.NotImplementedException();
        }

        #region Helpers

        private static void ChkDataIntegrity(DtoSuiteUsers entityToChk)
        {
            if (String.IsNullOrEmpty(entityToChk.Email) || String.IsNullOrWhiteSpace(entityToChk.Email))
                throw new ArgumentException(DomainExceptions.EmailNullException, "entityToChk");

            if (String.IsNullOrEmpty(entityToChk.Nome) || String.IsNullOrWhiteSpace(entityToChk.Nome))
                throw new ArgumentException(DomainExceptions.NomeNullException, "entityToChk");

            if (String.IsNullOrEmpty(entityToChk.Cognome) || String.IsNullOrWhiteSpace(entityToChk.Cognome))
                throw new ArgumentException(DomainExceptions.CognomeNullException, "entityToChk");

            if (!DomainValidationRules.ValidateEmail(entityToChk.Email))
                throw new ArgumentException(DomainExceptions.EmailWrongFormat, "entityToChk");
        }
        #endregion
    }
}
