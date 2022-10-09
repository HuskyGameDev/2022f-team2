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

public class LoadSetup : MonoBehaviour
{

    public GameObject SaveItemPrefab;

    public GameObject ContentGameObject;

    // Start is called before the first frame update
    async void Start()
    {
        // Current only for testing
        await SaveUtility.SaveAsync(new SaveData("test"));
        await SaveUtility.SaveAsync(new SaveData("test2", null, DateTime.MaxValue));
        await SaveUtility.SaveAsync(new SaveData("test2", null, DateTime.Today));
        Debug.Log("Loading Saves");
        var saves= await SaveUtility.GetSortedSavesAsync();
        Debug.Log("Found " + saves.Length + " saves in" + Application.persistentDataPath);
        foreach (var save in saves)
        {
            var saveItem = Instantiate(SaveItemPrefab, ContentGameObject.transform);
            saveItem.name = save.Name;
            saveItem.transform.parent = ContentGameObject.transform;
            /*int d = 2;
            Texture2D texture = new Texture2D(d,d);
            texture.LoadRawTextureData(save.Icon);
            saveItem.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(texture, new Rect(0,0,d,d), new Vector2(0.5f,0.5f));*/
            saveItem.transform.Find("Data").Find("Save Name").GetComponent<TextMeshProUGUI>().text = save.Name;
            
            saveItem.transform.Find("Data").Find("Save Date").GetComponent<TextMeshProUGUI>().text = save.Date.ToString(CultureInfo.CurrentCulture);
        }
    }
}
