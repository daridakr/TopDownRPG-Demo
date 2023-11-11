using UnityEngine;

[CreateAssetMenu(fileName = "Interaction", menuName = "Interaction")]
public class InteractionType : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private RuntimeAnimatorController _animator;

    public Sprite Icon => _icon;
    public RuntimeAnimatorController AnimatorController => _animator;
}
