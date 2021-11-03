using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Proveedor de almacenamiento de 
    /// SQLite.
    /// </summary>
    public class StorageProviderSQLite : IStorageProvider
    {
        bool IStorageProvider.Delete<T>(int recordId)
        {
            throw new System.NotImplementedException();
        }

        int IStorageProvider.Insert<T>(T record)
        {
            throw new System.NotImplementedException();
        }

        ReadOnlyCollection<T> IStorageProvider.SelectAll<T>()
        {
            throw new System.NotImplementedException();
        }

        bool IStorageProvider.Update<T>(T record)
        {
            throw new System.NotImplementedException();
        }
    }
}