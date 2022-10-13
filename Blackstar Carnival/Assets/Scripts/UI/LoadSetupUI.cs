using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using BlackstarCarnival;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LoadSetupUI : MonoBehaviour
{

    public GameObject SaveItemPrefab;
    public GameObject ContentGameObject;
    private List<SaveData> _saveItems = new List<SaveData>();

    // Start is called before the first frame update
    void Start()
    {
        // Current only for testing
        SaveUtility.Save(new SaveData("test"));
        SaveUtility.Save(new SaveData("test2", null, DateTime.MaxValue));
        SaveUtility.Save(new SaveData("test3", null, DateTime.Today));
        Refresh();
    }

    private void OnEnable()
    {
        Refresh();
    }

    void Refresh()
    {
        Debug.Log("Loading Saves");
        var saves= SaveUtility.GetSortedSaves();
        Debug.Log("Found " + saves.Length + " saves in" + Application.persistentDataPath);
        foreach (var save in saves)
        {
            if (_saveItems.Exists(x => x.Name == save.Name))
            {
                Debug.Log("Save already exists");
                continue;
            }
            _saveItems.Add(save);
            var saveItem = Instantiate(SaveItemPrefab, ContentGameObject.transform);
            saveItem.name = save.Name;
            saveItem.transform.SetParent(ContentGameObject.transform);
            saveItem.transform.GetComponent<LoadGameUI>().saveData = save;
            /*int d = 2;
            Texture2D texture = new Texture2D(d,d);
            texture.LoadRawTextureData(save.Icon);
            saveItem.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(texture, new Rect(0,0,d,d), new Vector2(0.5f,0.5f));*/
            saveItem.transform.Find("Data").Find("Save Name").GetComponent<TextMeshProUGUI>().text = save.Name;
            
            saveItem.transform.Find("Data").Find("Save Date").GetComponent<TextMeshProUGUI>().text = save.Date.ToString(CultureInfo.CurrentCulture);
        }
    }
}
