using KMA.C2018.Tools;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KMA.C2018.Managers
{
    class SerializationManager
    {
        internal static void Serialize<T>(T obj, string filePath)
        {
            try
            {
                FileFolderHelper.CheckAndCreateFile(filePath);
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to serialize data to file {filePath}", ex);
                throw;
            }
        }

        internal static T Deserialize<T>(string filePath) where T : class
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    return (T)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to Deserialize Data From File {filePath}", ex);
                return null;
            }
        }
    }
}
