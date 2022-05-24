using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UISlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UINote uiNote;
    private UIController controller;

    public string NoteText => this.uiNote.NoteText;

    private UIController _uiController;


    private void Start()
    {
        controller= GetComponentInParent<UIController>();
    }
    
    public void SetNote(Note note)
    {
        uiNote.NoteInfo = note ;
        Refresh();
    }

    public void DeleteNote()
    {
        controller.RemoveNote(this);
    }

    public void Refresh()
    {
        if(uiNote!=null)
            uiNote.Refresh();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.OpenEditingPanel(this);
    }
}
