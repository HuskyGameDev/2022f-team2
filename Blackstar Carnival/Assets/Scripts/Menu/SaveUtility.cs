using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class SaveUtility
    {
        private static string BasePath => Application.persistentDataPath;
        private const string SaveFileExtension = ".save";

        #region Get Saves
        public static bool SaveExistsWithName(string name) => 
            File.Exists(Path.Combine(BasePath, name + SaveFileExtension));

        public static SaveData[] GetSortedSaves()
        {
            var saveFiles = GetSaves();
            Array.Sort(saveFiles, (a, b) => b.date.CompareTo(a.date));
            return saveFiles;
        }
        
        private static SaveData[] GetSaves()
        {
            BinaryFormatter bf = new BinaryFormatter();
            var saveFiles = Directory.GetFiles(BasePath, $"*{SaveFileExtension}");
            var saveData = new SaveData[saveFiles.Length];
            for (var i = 0; i < saveFiles.Length; i++)
            {
                saveData[i] = GetSave(bf, saveFiles[i]);
            }

            return saveData;
        }
        
        private static SaveData GetSave(BinaryFormatter bf, string saveName)
        {
            Debug.Log("Attempting to fetch save: " + saveName);
            using var file = File.Open(Path.Combine(BasePath, saveName), FileMode.Open);
            return bf.Deserialize(file) as SaveData;
        }
        #endregion
        public static void Save(SaveData saveData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream file = File.Create(Path.Combine(BasePath, saveData.name + SaveFileExtension));
            bf.Serialize(file, saveData);
        }

        public static SaveData Load(SaveData saveData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return GetSave(bf, saveData.name);
        }
        
        public static void Delete(SaveData saveData)
        {
            File.Delete(Path.Combine(BasePath, saveData.name + SaveFileExtension));
        }

    }
}