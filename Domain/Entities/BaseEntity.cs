using Domain.ValueObjects;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Classe base das entidades
    /// </summary>
    [DataContract]
    [Serializable]
    public abstract class BaseEntity
    {
        #region Properties

        /// <summary>
        /// Identificador da entidade
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// Indicate entity is valid
        /// </summary>
        [XmlIgnore]
        public bool IsValid
        {
            get
            {
                try
                {
                    this.Validate();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validate Entity Data
        /// </summary>
        public abstract void Validate();

        #endregion Methods
    }
}
