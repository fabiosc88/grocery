using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    /// <summary>
    /// Service Base Class
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Generic Repository
        /// </summary>
        private readonly IBaseRepository<TEntity> _baseRepository;

        #endregion Properties

        #region Construtor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Generic repository associated with specific entity</param>
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _baseRepository = repository;
        }

        #endregion Construtor

        #region Get

        /// <summary>
        /// Get an object by Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <returns>Object</returns>
        public TEntity GetById(long id)
        {
            return _baseRepository.GetById(id);
        }

        /// <summary>
        /// Get the first object found and obyes the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns>First element</returns>
        public TEntity GetFirst(Func<TEntity, bool> wherePredicate)
        {
            return _baseRepository.GetFirst(wherePredicate);
        }

        #endregion Get

        #region List

        /// <summary>
        /// Lita todos os registros.
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> List()
        {
            return _baseRepository.List();
        }

        /// <summary>
        /// Lista todos os registro que obedeçam a expressão "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns></returns>
        public IList<TEntity> List(Func<TEntity, bool> wherePredicate)
        {
            return _baseRepository.List(wherePredicate);
        }

        #endregion List

        #region Dispose

        /// <summary>
        ///  Release object from memory
        /// </summary>
        public void Dispose()
        {
            if (_baseRepository != null)
                //Release a concrect class that implements an interface IBaseRepository
                _baseRepository.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
