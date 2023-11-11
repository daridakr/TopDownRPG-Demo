using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image _image;

    public void DisplayItem(string name, string cost, Sprite sprite)
    {
        _name.text = name;
        _cost.text = cost;
        _image.sprite = sprite;
    }
}
