using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameDisplay;

    public void DisplayName(string name)
    {
        _nameDisplay.text = name;
    }
}
