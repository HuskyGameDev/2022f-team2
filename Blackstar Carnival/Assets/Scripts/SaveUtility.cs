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

        public static bool SaveExists(SaveData saveData) => 
            File.Exists(Path.Combine(BasePath, saveData.Name + SaveFileExtension));

        public static async Task<SaveData[]> GetSortedSavesAsync()
        {
            var saveFiles = await GetSavesAsync();
            Array.Sort(saveFiles, (a, b) => b.Date.CompareTo(a.Date));
            return saveFiles;
        }
        
        private static async Task<SaveData[]> GetSavesAsync()
        {
            BinaryFormatter bf = new BinaryFormatter();
            var saveFiles = Directory.GetFiles(BasePath, $"*{SaveFileExtension}");
            var saveData = new SaveData[saveFiles.Length];
            for (var i = 0; i < saveFiles.Length; i++)
            {
                saveData[i] = await GetSaveAsync(bf, saveFiles[i]);
            }

            return saveData;
        }
        
        private static async Task<SaveData> GetSaveAsync(BinaryFormatter bf, string saveName)
        {
            Debug.Log("Attempting to load save: " + saveName);
            await using var file = File.Open(Path.Combine(BasePath, saveName), FileMode.Open);
            return await Task.Run(() => bf.Deserialize(file) as SaveData);
        }
        
        public static async Task SaveAsync(SaveData saveData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream file = File.Create(Path.Combine(BasePath, saveData.Name + SaveFileExtension));
            await Task.Run(() => bf.Serialize(file, saveData));
        }

    }
}