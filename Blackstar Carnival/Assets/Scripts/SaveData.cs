using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace BlackstarCarnival
{
    
    [Serializable]
    internal sealed class SaveData
    {
        internal SaveData(string name = "", byte[] icon = null, DateTime date = default, float3 playerPosition = default,
            FaceDirection faceDirection = FaceDirection.North, uint starBucks = 0, string currentScene = "")
        {
            Name = name;
            Icon = icon;
            Date = date;
            PlayerPosition = playerPosition;
            FaceDirection = faceDirection;
            StarBucks = starBucks;
            CurrentScene = currentScene;
        }
        
        public void Save() => SaveUtility.Save(this);
        public void Load() => SaveUtility.Load(this);
        public void Delete() => SaveUtility.Delete(this);

        #region Save Meta Data
        //TODO - Add some meta data
        public string Name;
        public byte[] Icon = {1}; // LIMITED TO 512x512
        public DateTime Date;
        #endregion
        
        #region Player Data
        public float3 PlayerPosition;
        public FaceDirection FaceDirection;
        public uint StarBucks;
        public string CurrentScene;
        #endregion
        
        #region Dialogue Data
        //TODO - Add Dialogue Data
        #endregion
    }
}
