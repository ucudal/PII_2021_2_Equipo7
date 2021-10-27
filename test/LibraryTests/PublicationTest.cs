using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Publication"/>.
    /// </summary>
    [TestFixture]
    public class PublicationTest
    {
        /// <summary>
        /// La publicacion para probar.
        /// </summary>
        private Publication publication;

        public PublicationItem PublicationItem {get; set;}

        /// <summary>
        /// Publication tiene una property de Company.
        /// </summary>
        public Company Company{get; set;}


        /// <summary>
        /// Id que se la da a cada publicación.
        /// </summary>
        public  int Id{get; set;}

        /// <summary>
        /// DateTime con la fecha de activación.
        /// </summary>
        public DateTime ActiveFrom{get; set;}

        /// <summary>
        /// Datetime con la fecha de desactivación de la publicación.
        /// </summary>
        public DateTime ActiveUntill{get; set;}

        /// <summary>
        /// Precio de lo que se vende en la publicación, ya sea un material o varios.
        /// </summary>
        public int Price{get; set;}

        /// <summary>
        /// Divisa del precio del material o materiales.
        /// </summary>
        public Currency Currency{get; set;}

        /// <summary>
        ///  Deleted sirve para saber si la publicación se borra o no.
        /// </summary>
        public bool Deleted{get; set;}

        /// <summary>
        /// Crea una publicacion para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.publication = new Publication();
        }

        [Test]
        public void Constructor_Test(DateTime ActiveFrom, DateTime ActiveUntill, int Price, Currency Currency, bool Deleted)
        {

        }



    }
}