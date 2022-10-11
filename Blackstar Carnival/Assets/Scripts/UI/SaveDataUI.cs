using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class SaveDataUI : MonoBehaviour
    {
        
        public SaveData saveData;
        
        public void Save()
        {
            throw new System.NotImplementedException();
        }
        
        public void Load()
        {
            throw new System.NotImplementedException();
        }
        
        public void Delete()
        {
            SaveUtility.DeleteSave(saveData);
            Destroy(gameObject);
        }
    }
}
