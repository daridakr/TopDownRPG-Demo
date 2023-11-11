using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPC : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private NameDisplay _nameDisplayer;

    public string Name => _name;

    private void Awake()
    {
        _nameDisplayer.DisplayName(_name);
    }
}
