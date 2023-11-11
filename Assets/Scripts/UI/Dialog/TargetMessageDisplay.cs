using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetMessageDisplay : MessageDisplay
{
    [SerializeField] private Image _avatar;

    public void DisplayMessage(string text, Sprite avatar)
    {
        base.DisplayMessage(text);

        _avatar.sprite = avatar;
    }
}
