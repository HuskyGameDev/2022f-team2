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
            var saveName = InteractableTextField.GetComponent<TextMeshProUGUI>().text;
            if (saveName.Equals("")) return;
            if (SaveUtility.SaveExistsWithName(saveName)) return;
            
            // TODO: Add data to save game.
            saveData.name = InteractableTextField.GetComponent<TextMeshProUGUI>().text;
            saveData.date = DateTime.Now;
            saveData.Save();
            gameObject.SetActive(false);
            LoadGameMenu.SetActive(true);
        }
    }
}

