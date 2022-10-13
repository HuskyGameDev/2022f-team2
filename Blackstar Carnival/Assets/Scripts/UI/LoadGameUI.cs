using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class LoadGameUI : MonoBehaviour
    {
        [HideInInspector]
        public SaveData saveData;
        
        public void Load()
        {
            saveData.Load();
        }
        
        public void Delete()
        {
            saveData.Delete();
            Destroy(gameObject);
        }
        
        
    }
}
