using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private EditingPanel editingPanel;

    private List<UINote> _notes;

    private void Start()
    {
        _notes = new List<UINote>();
        _notes = GetComponentsInChildren<UINote>().ToList();
        try
        {
            var savedNotes = JsonLoader.GetInstance().Load();
            
            if (savedNotes.Count == 0)
                AddNote(new Note("Добавить новую заметку"));
            
            foreach (var note in savedNotes)
            {
                AddNote(note);
            }
            
        }
        catch (Exception e)
        {
            var note = new Note("Добавить новую заметку");
            AddNote(note);
        }
    }

    private void Save()
    {
        if ( _notes ==null || _notes.Count == 0 )
            return;
        
        var notes = new List<Note>();
        foreach (var note in _notes)
        {
            notes.Add(note.NoteInfo);
        }
        JsonLoader.GetInstance().Save(notes);
    }
    private void OnApplicationQuit()=>
        Save();
    
    private void OnApplicationFocus(bool hasFocus)=>
        Save();
    
    
    private void AddNote(Note note)
    {
        var uiNote =  Instantiate(notePrefab, this.transform).GetComponent<UINote>();
        uiNote.NoteInfo = note;
        _notes.Add( uiNote);
    }
    
    public void AddNote()
    {
        var uiNote =  Instantiate(notePrefab, this.transform).GetComponent<UINote>();

        _notes.Add( uiNote);
        OpenEditingPanel(uiNote);
    }
    
    public void RemoveNote( UINote note)
    {
        _notes.Remove(note );
        Destroy(note.gameObject);
    }

    public void OpenEditingPanel(UINote note)
    {
        editingPanel.gameObject.SetActive(true);
        editingPanel.StartEditing(note);
    }


}
