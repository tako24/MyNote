using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JsonLoader 
{
    private string fileName = "/Notes.json";
    private static JsonLoader _instance; 
    
    public static JsonLoader GetInstance()
    {
        if (_instance == null)
            _instance = new JsonLoader();
        return _instance;
    }
    
    public void Save(List<Note> notes)
    {
        File.WriteAllText(Application.streamingAssetsPath + fileName,JsonHelper.ToJson(notes.ToArray(), true));
    }
    
    public List<Note> Load()
    {
        var jsonText = File.ReadAllText(Application.streamingAssetsPath + fileName);
        var notes = JsonHelper.FromJson<Note>(jsonText);
        
        return notes.ToList();
    }
}
