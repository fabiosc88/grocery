using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Contract of Base Repository Class.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Insert

        /// <summary>
        /// Insert new record
        /// </summary>
        /// <param name="entity">Object instance</param>
        void Create(TEntity entity);

        #endregion Insert

        #region Update

        /// <summary>
        /// Upate existence object
        /// </summary>
        /// <param name="entity">Object instance</param>
        void Update(TEntity entity);

        #endregion Update

        #region Delete

        /// <summary>
        /// Logically Delete
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);

        #endregion Delete

        #region Get

        /// <summary>
        /// Obtém um registro pelo Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <returns>Object</returns>
        TEntity GetById(long id);

        /// <summary>
        /// Obtém o primeiro objeto encontrado que obedeça a expressão "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns>First element</returns>
        TEntity GetFirst(Func<TEntity, bool> wherePredicate);

        #endregion Get

        #region List

        /// <summary>
        /// Lita todos os registros.
        /// </summary>
        /// <returns>Retorna um Queryable contendo todos os registros e seus registros relacionados.</returns>
        IList<TEntity> List();

        /// <summary>
        /// Lista todos os registro que obedeçam a expressão "where"
        /// </summary>
        /// <param name="predicadoWhere">Lambda Expression "Where" to buil an sql</param>
        /// <returns>Retorna uma de lista com todos os registros que obedece a condição com todos os registros relacionados</returns>
        IList<TEntity> List(Func<TEntity, bool> wherePredicate);

        #endregion List

        #region Transactions Methods

        /// <summary>
        /// Save transaction
        /// </summary>
        void SaveChanges();

        #endregion Transactions Methods

        #region Dispose

        /// <summary>
        /// Release object from memory
        /// </summary>
        void Dispose();

        #endregion Dispose
    }
}