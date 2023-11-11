using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroup))]
public class InteractingButton : MonoBehaviour
{
    [SerializeField] private PlayerInteractions _interactor;
    [SerializeField] private Image _icon;
    [SerializeField] private Animator _animator;

    private CanvasGroup _display;
    private Action _action;

    private void OnEnable()
    {
        _interactor.Entered += ShowButton;
        _interactor.Exit += HideButton;
    }

    private void Awake()
    {
        _display = GetComponent<CanvasGroup>();
    }

    protected void ShowButton(IInteracting interacting)
    {
        _display.alpha = 1;

        RuntimeAnimatorController animatedIcon = interacting.Animator;

        if (animatedIcon != null)
        {
            _animator.runtimeAnimatorController = animatedIcon;
        }
        else
        {
            _icon.sprite = interacting.Icon;
        }

        _action += interacting.Interact;
    }

    protected void HideButton()
    {
        _display.alpha = 0;
        _action = null;
    }

    public void Interact()
    {
        if (_action != null)
        {
            _action.Invoke();
            HideButton();
        }
    }

    private void OnDisable()
    {
        _interactor.Entered -= ShowButton;
        _interactor.Exit -= HideButton;
    }
}
