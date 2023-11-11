using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private Fishing _fishing;
    [SerializeField] private InventoryChest _chest;

    public UnityAction<IInteracting> Entered;
    public UnityAction Exit;

    private void OnEnable()
    {
        _fishing.Fished += _chest.PutItem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracting interacting))
        {
            Entered?.Invoke(interacting);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracting interacting))
        {
            Exit?.Invoke();
        }
    }

    private void OnDisable()
    {
        _fishing.Fished -= _chest.PutItem;
    }
}
