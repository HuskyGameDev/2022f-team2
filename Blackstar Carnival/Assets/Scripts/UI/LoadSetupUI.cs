using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class LoadSetupUI : MonoBehaviour
    {
        public GameObject SaveItemPrefab;
        public GameObject ContentGameObject;
        [HideInInspector]
        public static List<SaveData> Saves = new List<SaveData>();

        
        private void OnEnable()
        {
            Refresh();
        }

        void Refresh()
        {
            int i = 0;
            var saves= SaveUtility.GetSortedSaves();
            foreach (var save in saves)
            {
                if (Saves.Exists(x => x.name == save.name)) continue;
                
                Saves.Add(save);
                var saveItem = Instantiate(SaveItemPrefab, ContentGameObject.transform);
                saveItem.transform.SetSiblingIndex(i++);
                saveItem.name = save.name;
                saveItem.transform.SetParent(ContentGameObject.transform);
                saveItem.transform.GetComponent<LoadGameUI>().saveData = save;
                // TODO: Fix this
                /*int d = 2;
                Texture2D texture = new Texture2D(d,d);
                texture.LoadRawTextureData(save.icon);
                saveItem.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(texture, new Rect(0,0,d,d), new Vector2(0.5f,0.5f));*/
                saveItem.transform.Find("Data").Find("Save Name").GetComponent<TextMeshProUGUI>().text = save.name;
                saveItem.transform.Find("Data").Find("Save Date").GetComponent<TextMeshProUGUI>().text = save.date.ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}
