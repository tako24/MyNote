using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note 
{
    public string Text { get; }
    public DateTime CreationDate { get;  }
    public bool IsDone { get;  }

    public Note(string text)
    {
        Text = text;
        IsDone = false;
        CreationDate = DateTime.Now;
    }
}
