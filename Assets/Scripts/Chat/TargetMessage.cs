using UnityEngine;

public class TargetMessage : Message
{
    private Sprite _avatar;

    public Sprite Avatar => _avatar;

    public TargetMessage(string text, Sprite avatar) : base(text)
    {
        _avatar = avatar;
    }
}

public class Message
{
    private string _text;

    public string Text => _text;

    public Message(string text)
    {
        _text = text;
    }
}
