using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class WindowDisplay : MonoBehaviour
{
    private CanvasGroup _canvasDisplay;

    public bool IsDisplaing => _canvasDisplay.blocksRaycasts;

    public UnityAction Displayed;
    public UnityAction Closed;

    private void Awake()
    {
        _canvasDisplay = GetComponent<CanvasGroup>();
    }

    protected void ShowWindow()
    {
        _canvasDisplay.alpha = 1;
        _canvasDisplay.blocksRaycasts = true;
        Displayed?.Invoke();
    }

    public void HideWindow()
    {
        _canvasDisplay.alpha = 0;
        _canvasDisplay.blocksRaycasts = false;
        Closed?.Invoke();
    }
}
