using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadScript : MonoBehaviour
{

    string _filePath;

    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
    }


    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate);

        Save save = new Save();

        save.SaveColors(save.SavedColors);

        bf.Serialize(fs, save);

        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(_filePath))
        {
            print("Файл с сохранением не найден");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Open);
        
        Save save = (Save)bf.Deserialize(fs);

        LoadData(save);

        fs.Close();
    }

    public void LoadData(Save save)
    {
        GameObject[] figures = GameObject.FindGameObjectsWithTag("GameFigure");

        for (int i = 0; i < figures.Length; i++)
        {
            Color cl = new Color(save.SavedColors[i].r, save.SavedColors[i].g, save.SavedColors[i].b, save.SavedColors[i].a);
            figures[i].GetComponent<Renderer>().material.color = cl;           
        }

    }

}



[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct MyColor
    {
        public float r, g, b, a;

        public MyColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        
    }

    public List<MyColor> SavedColors = new List<MyColor>();

    public void SaveColors(List<MyColor> colors)
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("GameFigure"))
        {
            var color = go.GetComponent<Renderer>().material.color;
            SavedColors.Add(new MyColor(color.r, color.g, color.b, color.a));
        }

    }


}

