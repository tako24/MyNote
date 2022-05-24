using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditingPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private UISlot selectedSlot;

    public void StartEditing(UISlot slot)
    {
        selectedSlot = slot;
        inputField.text = slot.NoteText;
    }
    public void EditNote()
    {
        selectedSlot.SetNote(new Note(inputField.text));
        selectedSlot.Refresh();
        this.gameObject.SetActive(false);
    }
    
}
