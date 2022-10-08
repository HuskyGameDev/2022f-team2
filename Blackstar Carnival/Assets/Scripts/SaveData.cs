using System;
using UnityEngine;

namespace BlackstarCarnival
{
    
    [CreateAssetMenu(fileName = "DefaultSaveData.asset", menuName = "BlackstarCarnival/Default SaveData")]
    internal sealed class SaveData : ScriptableObject
    {
        
        #region Save Meta Data
        //TODO - Add some meta data
        public string SaveName;
        public Texture2D SaveIcon;
        public DateTime SaveTime;
        #endregion
        
        #region Player Data
        public Vector3 playerPosition;
        public FaceDirection faceDirection;
        public uint starBucks;
        public string currentScene;
        #endregion
        
        #region Dialogue Data
        //TODO - Add Dialogue Data
        #endregion
    }
}
