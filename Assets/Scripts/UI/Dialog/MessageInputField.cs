using TMPro;
using UnityEngine;

[RequireComponent (typeof(TMP_InputField))]
public class MessageInputField : MonoBehaviour
{
    [SerializeField] DialogDisplay _dialogDisplay;

    private TMP_InputField _inputField;

    private void OnEnable()
    {
        _dialogDisplay.MessageSent += OnMessageSent;
    }

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    private void OnMessageSent()
    {
        _inputField.text = "";
    }

    private void OnDisable()
    {
        _dialogDisplay.MessageSent -= OnMessageSent;
    }
}
