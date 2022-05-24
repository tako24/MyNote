using System;

[Serializable]
public class Note
{
    public string Text;
    public string CreationDate;
    public bool IsDone;
    public Note(string text)
    {
        Text = text;
        IsDone = false;
        CreationDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");
    }
    
}
