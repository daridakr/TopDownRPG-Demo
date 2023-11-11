using TMPro;
using UnityEngine;

public class InfoWindow : WindowDisplay
{
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _info;

    public void DisplayInfo(string headerText, string infoText)
    {
        _header.text = $"{headerText} Info";
        _info.text = infoText;
        ShowWindow();
    }
}
