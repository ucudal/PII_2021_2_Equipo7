using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// <param name="pubId">Id de la publicación relevante</param>
        /// <param name="keyWord">Palabra a verificar.</param>
        /// <returns>Valor booleano indicacndo si la palabra existe en la lista de palabras clave o no.</returns>
        public bool PublicationMatchesKeyWord(int pubId, string keyWord)
        {
            IReadOnlyCollection<PublicationKeyWord> keyWords = this.Items;
            foreach (PublicationKeyWord word in keyWords)
            {
                if (word.PublicationId == pubId && word.KeyWord.ToLower() == keyWord.ToLower())
                {
                    return true;
                }
            }

            return false;
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
            DataManager dataManager = new DataManager();
            if(item.KeyWord is null || item.KeyWord.Length == 0) 
                throw new ValidationException("Requerida palabra clave.");
            if(item.PublicationId == 0/* || !dataManager.Publication.Exists(item.PublicationId)*/) 
                throw new ValidationException("Requerida publicacion asociada.");
        }
    }
}