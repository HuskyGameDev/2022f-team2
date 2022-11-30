using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BlackstarCarnival
{
    
    [Serializable]
    internal sealed class SaveData
    {
        [DoNotSerialize] public static SaveData Current { get; private set; }
        internal SaveData(string name = "", byte[] icon = null, DateTime date = default, float3 playerPosition = default,
            FaceDirection faceDirection = FaceDirection.North, uint starBucks = 0, string currentScene = "")
        {
            this.name = name;
            this.icon = icon;
            this.date = date;
            this.playerPosition = playerPosition;
            this.faceDirection = faceDirection;
            this.starBucks = starBucks;
            this.currentScene = currentScene;
        }
        
        public void Save() => SaveUtility.Save(this);
        public void Load() => Current = SaveUtility.Load(this);

        public void Delete()
        {
            LoadSetupUI.Saves.Remove(this);
            SaveUtility.Delete(this);
        } 

        #region Save Meta Data
        //TODO - Add some meta data
        public string name;
        public byte[] icon; // LIMITED TO 512x512
        public DateTime date;
        #endregion
        
        #region Player Data
        public float3 playerPosition;
        public FaceDirection faceDirection;
        public uint starBucks;
        public string currentScene;
        #endregion
        
        #region Dialogue Data
        //TODO - Add Dialogue Data
        #endregion
    }
}
