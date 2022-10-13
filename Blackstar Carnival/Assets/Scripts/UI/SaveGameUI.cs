using System;
using TMPro;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class SaveGameUI : MonoBehaviour
    {
        [HideInInspector]
        public SaveData saveData;
        public GameObject InteractableTextField;
        public GameObject LoadGameMenu;

        
        // TODO: Fix bug where no save name does not prevent save
        public void SaveGame()
        {
            if (InteractableTextField.GetComponent<TextMeshProUGUI>().text.Equals("")) return;
            saveData.name = InteractableTextField.GetComponent<TextMeshProUGUI>().text;
            saveData.date = DateTime.Now;
            saveData.Save();
            gameObject.SetActive(false);
            LoadGameMenu.SetActive(true);
        }
    }
}

