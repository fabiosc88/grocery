using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Infra.Data.Repositories
{
    /// <summary>
    /// Base Repository Class.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        /// <summary>
        /// XML file path
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// Entity List
        /// </summary>
        private readonly IList<TEntity> _entityList;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRepository()
        {
            _fileName = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "/"+ typeof(TEntity).Name + ".xml";

            this.CreateXmlFile();

            XmlSerializer serializer = new XmlSerializer(typeof(List<TEntity>), new XmlRootAttribute("ArrayOf" + typeof(TEntity).Name));
            using (StreamReader myWriter = new StreamReader(_fileName))
            {
                _entityList = (List<TEntity>)serializer.Deserialize(myWriter);
                myWriter.Close();
            }
        }

        #endregion Constructor

        #region Create

        /// <summary>
        /// Insert new record
        /// </summary>
        /// <param name="entity">Object instance</param>
        public void Create(TEntity entity)
        {
            //Get the last Id of list
            entity.Id = _entityList.Count > 0 ? _entityList.Max(x => x.Id) + 1 : 1;
            _entityList.Add(entity);

            if (entity.IsValid)
                SaveChanges();
        }

        #endregion Create

        #region Update

        /// <summary>
        /// Upate existence object
        /// </summary>
        /// <param name="entity">Object instance</param>
        public void Update(TEntity entity)
        {
            //Get element in List
            var entityDB = GetById(entity.Id);

            //Remove
            _entityList.Remove(entityDB);

            //Insert
            _entityList.Add(entity);

            if (entity.IsValid)
                SaveChanges();
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(TEntity entity)
        {
            _entityList.Remove(entity);
            SaveChanges();
        }

        #endregion Delete

        #region Get

        /// <summary>
        /// Obtém um registro pelo Id
        /// </summary>
        /// <param name="id">Entity Identifier</param>
        /// <returns>Object</returns>
        public TEntity GetById(long id)
        {
            return (from entity in _entityList where entity.Id == id select entity).FirstOrDefault();
        }

        /// <summary>
        /// Obtém o primeiro objeto encontrado que obedeça a expressão "where"
        /// </summary>
        /// <param name="wherePredicate">Lambda Expression "Where" to buil an sql</param>
        /// <returns>First element</returns>
        public TEntity GetFirst(Func<TEntity, bool> wherePredicate)
        {
            return _entityList.FirstOrDefault(wherePredicate);
        }

        #endregion Get

        #region List

        /// <summary>
        /// Lita todos os registros.
        /// </summary>
        /// <returns>Retorna um Queryable contendo todos os registros e seus registros relacionados.</returns>
        public IList<TEntity> List()
        {
            return _entityList;
        }

        /// <summary>
        /// Lista todos os registro que obedeçam a expressão "where"
        /// </summary>
        /// <param name="predicadoWhere">Lambda Expression "Where" to buil an sql</param>
        /// <returns>Retorna uma de lista com todos os registros que obedece a condição com todos os registros relacionados</returns>
        public IList<TEntity> List(Func<TEntity, bool> wherePredicate)
        {
            return _entityList.Where(wherePredicate).ToList();
        }

        #endregion List

        #region Transactions Methods

        /// <summary>
        /// Save transaction
        /// </summary>
        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TEntity>), new XmlRootAttribute("ArrayOf" + typeof(TEntity).Name));
            using (StreamWriter myWriter = new StreamWriter(_fileName))
            {
                serializer.Serialize(myWriter, _entityList);
                myWriter.Close();
            }
        }

        #endregion Transactions Methods

        #region Dispose

        /// <summary>
        /// Release object from memory
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Dispose

        #region Private Methods

        /// <summary>
        /// Create a XML File
        /// </summary>
        private void CreateXmlFile()
        {
            if (!File.Exists(_fileName))
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    NewLineOnAttributes = true
                };

                using (XmlWriter writer = XmlWriter.Create(_fileName, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("ArrayOf" + typeof(TEntity).Name);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
        
        #endregion Private Methods
    }
}
