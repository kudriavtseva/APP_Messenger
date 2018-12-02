using System;
using System.IO;

namespace KMA.C2018.Tools
{
    public class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "Messenger");

        public static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        public static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("YYYY_MM_DD") + ".txt");

        public static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.mes");

        public static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.mes");

        public static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
