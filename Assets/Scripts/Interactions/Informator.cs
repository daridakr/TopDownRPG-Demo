using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Informator : MonoBehaviour, IInteracting
{
    [SerializeField] private InteractionType _interactionType;
    [SerializeField] private string _informationHeader;
    [SerializeField] private string _informationText;
    [SerializeField] private InfoWindow _infoWindow;

    public InteractionType InteractionType { get => _interactionType; set => _interactionType = value; }

    public void Interact()
    {
        _infoWindow.DisplayInfo(_informationHeader, _informationText);
    }
}
