using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UINote : MonoBehaviour//, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private TextMeshProUGUI uiDateTime;
    [SerializeField] private Toggle uiCheckBox;
    private Note noteInfo;
    private int mainMenuTextLeanght = 50;
    public string NoteText => noteInfo.Text;
    public Note NoteInfo
    {
        set
        {
            noteInfo = value;
            Refresh();
        }
        
    }
    
    
    public void Refresh()
    {
        if (noteInfo ==null)
            return;
        if (noteInfo.Text.Length > mainMenuTextLeanght)
            uiText.text = noteInfo.Text.Substring(0, mainMenuTextLeanght) + "...";
        else
            uiText.text = noteInfo.Text;
        uiDateTime.text = noteInfo.CreationDate.ToString("dddd, dd MMMM yyyy");
        uiCheckBox.isOn = noteInfo.IsDone;
    }
    public void CleanUp()
    {
        
    }
}
