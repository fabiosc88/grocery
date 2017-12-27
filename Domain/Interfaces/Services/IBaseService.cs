using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Services
{
    /// <summary>
    /// Contract of Base Service Class.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        #region Get

        /// <summary>
        /// Get an object by Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <returns>Object</returns>
        TEntity GetById(long id);

        /// <summary>
        /// Get the first object found and obyes the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns>First element</returns>
        TEntity GetFirst(Func<TEntity, bool> wherePredicate);

        #endregion Get

        #region List

        /// <summary>
        /// List all registers
        /// </summary>
        /// <returns></returns>
        IList<TEntity> List();

        /// <summary>
        /// List all registers which obey the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns></returns>
        IList<TEntity> List(Func<TEntity, bool> wherePredicate);

        #endregion List
    }
}
