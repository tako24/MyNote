using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UINote : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private TextMeshProUGUI uiDateTime;
    [SerializeField] private Toggle uiCheckBox;
    
    private UIController _controller;
    private Note _noteInfo;
    private const int MainMenuTextLenght = 50;
    public string NoteText => _noteInfo.Text;
    public Note NoteInfo
    {
        set
        {
            _noteInfo = value;
            Refresh();
        }
        get => _noteInfo;
    }
    
    private void Awake()
    {
        _controller= GetComponentInParent<UIController>();
        NoteInfo = new Note("Новая заметка");
    }

    public void DeleteNote() =>
        _controller.RemoveNote(this);
    
    public void OnPointerClick(PointerEventData eventData)=>
        _controller.OpenEditingPanel(this);
    
    public void Refresh()
    {
        if (_noteInfo ==null)
            return;
        
        if (_noteInfo.Text.Length > MainMenuTextLenght)
            uiText.text = _noteInfo.Text[..MainMenuTextLenght] + "...";
        else
            uiText.text = _noteInfo.Text;
        
        uiDateTime.text = _noteInfo.CreationDate;
        uiCheckBox.isOn = _noteInfo.IsDone;
    }
}
