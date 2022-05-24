using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private EditingPanel editingPanel;
    private List<UISlot> slots;

    private void Start()
    {
        slots = new List<UISlot>();
        slots = GetComponentsInChildren<UISlot>().ToList();
    }

    public void RemoveNote( UISlot slot)
    {
        slots.Remove(slot );
        Destroy(slot.gameObject);
    }
    public void AddNote()
    {
        var slot =  Instantiate(notePrefab, this.transform).GetComponent<UISlot>();
        slot.SetNote(new Note("Новая заметка"));
        slots.Add( slot);
        OpenEditingPanel(slot);
    }
    public void AddNote(string text)
    {
        var slot =  Instantiate(notePrefab, this.transform).GetComponent<UISlot>();
        slot.SetNote(new Note(text));
        slots.Add( slot);
    }

    public void OpenEditingPanel(UISlot slot)
    {
        editingPanel.gameObject.SetActive(true);
        editingPanel.StartEditing(slot);
    }

}
