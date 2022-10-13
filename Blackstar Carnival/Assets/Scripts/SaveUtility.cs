using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Mono.Collections.Generic;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class SaveUtility
    {
        private static string BasePath => Application.persistentDataPath;
        private const string SaveFileExtension = ".save";

        #region Get Saves
        public static bool SaveExists(SaveData saveData) => 
            File.Exists(Path.Combine(BasePath, saveData.Name + SaveFileExtension));

        public static SaveData[] GetSortedSaves()
        {
            var saveFiles = GetSaves();
            Array.Sort(saveFiles, (a, b) => b.Date.CompareTo(a.Date));
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
            Debug.Log("Attempting to load save: " + saveName);
            using var file = File.Open(Path.Combine(BasePath, saveName), FileMode.Open);
            return bf.Deserialize(file) as SaveData;
        }
        #endregion
        public static void Save(SaveData saveData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream file = File.Create(Path.Combine(BasePath, saveData.Name + SaveFileExtension));
            bf.Serialize(file, saveData);
        }

        public static void Load(SaveData saveData)
        {
            // TODO: Load player controller, scene, dialog flags, etc.
            throw new NotImplementedException();
        }
        
        public static void Delete(SaveData saveData)
        {
            File.Delete(Path.Combine(BasePath, saveData.Name + SaveFileExtension));
        }

    }
}