using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    public UnityAction<string, TargetMessage> Started;

    private List<Message> _messages;

    public IEnumerable<Message> Messages => _messages;

    private void Awake()
    {
        _messages = new List<Message>();
    }

    public void StartDialogWith(DialogTarget target)
    {
        TargetMessage message = new TargetMessage(target.Answer, target.Sprite);
        _messages.Add(message);
        Started?.Invoke(target.Name, message);
    }

    public Message CreateMessage(string text)
    {
        Message message = new Message(text);
        _messages.Add(message);
        return message;
    }
}
