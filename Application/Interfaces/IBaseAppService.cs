using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    /// <summary>
    /// Contract of Base App Class.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IBaseAppService<TEntity> : IDisposable where TEntity : class
    {
        #region Get

        /// <summary>
        /// Get an object by Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns>Object</returns>
        TEntity GetById(long id, bool lazyLoad = false);

        /// <summary>
        /// Get the first object found and obyes the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to build an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns>First element</returns>
        TEntity GetFirst(Func<TEntity, bool> wherePredicate, bool lazyLoad = false);

        #endregion Get

        #region List

        /// <summary>
        /// List all registers
        /// </summary>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        IList<TEntity> List(bool lazyLoad = false);

        /// <summary>
        /// List all registers which obey the expression "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <param name="lazyLoad">Entities of Relationships</param>
        /// <returns></returns>
        IList<TEntity> List(Func<TEntity, bool> wherePredicate, bool lazyLoad = false);

        #endregion List
    }
}
