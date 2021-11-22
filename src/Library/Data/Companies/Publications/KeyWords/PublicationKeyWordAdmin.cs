// -----------------------------------------------------------------------
// <copyright file="PublicationKeyWordAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// Administrador de registros de
    /// palabras clave asociadas a las
    /// publicaciones.
    /// </summary>
    public sealed class PublicationKeyWordAdmin : DataAdmin<PublicationKeyWord>
    {
        /// <summary>
        /// Verifica si una publicación tiene una palabra concreta entre sus palabras claves.
        /// </summary>
        /// <param name="pubId">Id de la publicación relevante.</param>
        /// <param name="keyWord">Palabra a verificar.</param>
        /// <returns>Valor booleano indicado si la palabra existe en la lista de palabras clave o no.</returns>
        public bool PublicationMatchesKeyWord(int pubId, string keyWord)
        {
            IReadOnlyCollection<PublicationKeyWord> keyWords = this.Items;
            if (keyWord is null)
            {
                throw new ArgumentNullException(paramName: nameof(keyWord));
            }

            foreach (PublicationKeyWord word in keyWords)
            {
                if (word.PublicationId == pubId && word.KeyWord.ToUpperInvariant() == keyWord.ToUpperInvariant())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene una lista de publicaciones que tienen una palabra clave en concreto.
        /// </summary>
        /// <param name="keyWord">Palabra clave por la cual se van a buscar las publicaciones.</param>
        /// <returns>Listado de int con las publicaciones obtenidas.</returns>
        public IReadOnlyCollection<int> GetPublicationFromKeyWord(string keyWord)
        {
            List<int> resultList = new List<int>();
            foreach (PublicationKeyWord xPubWord in this.Items)
            {
                if (xPubWord.KeyWord == keyWord)
                {
                    resultList.Add(xPubWord.PublicationId);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene una lista de palabras que actuan como palabra clave para una publicación concreta.
        /// </summary>
        /// <param name="pubId">Id de la publicación para la cual se busca obtener sus palabras claves.</param>
        /// <returns>Listado de strings con las palabras claves obtenidas.</returns>
        public IReadOnlyCollection<string> GetKeyWordsForPublication(int pubId)
        {
            List<string> resultList = new List<string>();
            IReadOnlyCollection<PublicationKeyWord> keyWords = this.Items;
            foreach (PublicationKeyWord word in keyWords)
            {
                if (word.PublicationId == pubId)
                {
                    resultList.Add(word.KeyWord);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <inheritdoc/>
        protected override void ValidateData(PublicationKeyWord item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(paramName: nameof(item));
            }

            DataManager dataManager = new DataManager();
            if (item.KeyWord is null || item.KeyWord.Length == 0)
            {
                throw new ValidationException("Requerida palabra clave.");
            }

            if (item.PublicationId == 0/* || !dataManager.Publication.Exists(item.PublicationId)*/)
            {
                throw new ValidationException("Requerida publicacion asociada.");
            }
        }
    }
}