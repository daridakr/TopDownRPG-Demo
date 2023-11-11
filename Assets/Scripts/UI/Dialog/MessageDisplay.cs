using TMPro;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    public void DisplayMessage(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            _textField.text = text;
        }
        else
        {
            _textField.text = "Hi!";
        }
    }
}
