using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Dialog))]
public class DialogDisplay : WindowDisplay
{
    [SerializeField] private TargetMessageDisplay _targetMessageTemplate;
    [SerializeField] private MessageDisplay _heroMessageTemplate;
    [SerializeField] private Transform _chatField;
    [SerializeField] private TMP_Text _targetName;

    public UnityAction MessageSent;

    private Dialog _dialog;
    private TargetMessage _targetMessage;

    private void OnEnable()
    {
        _dialog = GetComponent<Dialog>();
        _dialog.Started += DisplayDialog;
    }

    public void DisplayDialog(string name, TargetMessage firstMessage)
    {
        _targetName.text = name;
        _targetMessage = firstMessage;
        ShowWindow();
        Answer();
    }

    private void SendMessage(TMP_Text content)
    {
        MessageDisplay heroMessage = Instantiate(_heroMessageTemplate, _chatField);
        Message newMessage = _dialog.CreateMessage(content.text);
        heroMessage.DisplayMessage(newMessage.Text);
        MessageSent?.Invoke();
        Answer();
    }

    private void Answer()
    {
        TargetMessageDisplay targetMessage = Instantiate(_targetMessageTemplate, _chatField);
        targetMessage.DisplayMessage(_targetMessage.Text, _targetMessage.Avatar);
    }

    private void OnDisable()
    {
        _dialog.Started -= DisplayDialog;
    }
}
