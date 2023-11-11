using UnityEngine;

public interface IInteracting
{
    public InteractionType InteractionType { get; set; }

    public Sprite Icon => InteractionType.Icon;
    public RuntimeAnimatorController Animator => InteractionType.AnimatorController;

    public abstract void Interact();
}
