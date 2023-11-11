using UnityEngine;

[RequireComponent (typeof(CanvasGroup))]
public class JoystickDisplayer : MonoBehaviour
{
    [SerializeField] private WindowDisplay[] _windows;

    private CanvasGroup _canvasDisplay;

    private void OnEnable()
    {
        foreach (var window in _windows)
        {
            window.Displayed += Hide;
            window.Closed += Show;
        }
    }

    private void Awake()
    {
        _canvasDisplay = GetComponent<CanvasGroup>();
    }

    private void Show()
    {
        _canvasDisplay.alpha = 1;
    }

    private void Hide()
    {
        _canvasDisplay.alpha = 0;
    }

    private void OnDisable()
    {
        foreach (var window in _windows)
        {
            window.Displayed -= Hide;
            window.Closed -= Show;
        }
    }
}
