using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditingPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private UINote _selectedNote;

    public void StartEditing(UINote note)
    {
        if (note == null) Debug.Log("note is null");
        if (note.NoteInfo == null) Debug.Log("noteinfo is null");
        _selectedNote = note;
        inputField.text = note.NoteText;
    }
    public void EditNote()
    {
        _selectedNote.NoteInfo =new Note(inputField.text);
        _selectedNote.Refresh();
        this.gameObject.SetActive(false);
    }
    
}
