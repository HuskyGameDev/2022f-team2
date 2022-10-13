using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlackstarCarnival
{
    internal sealed class SaveGameUI : MonoBehaviour
    {
        [HideInInspector]
        public SaveData saveData;

        public GameObject InteractableTextField;
        
        public void SaveGame()
        {
            saveData.Name = InteractableTextField.GetComponent<TextMeshProUGUI>().text;
            saveData.Save();
        }
    }
}

