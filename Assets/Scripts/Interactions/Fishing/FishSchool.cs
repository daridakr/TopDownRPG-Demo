using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class FishSchool : MonoBehaviour, IInteracting
{
    [SerializeField] private InteractionType _interactionType;
    [SerializeField] private Fish[] _fishes;
    [SerializeField] private int _fishAmount;

    public InteractionType InteractionType { get => _interactionType; set => _interactionType = value; }
    public bool IsEmpty => _fishAmount <= 0;
    private int CatchChances => _fishes.Sum(x => x.CatchChance);

    public UnityAction<FishSchool> Fishing;

    public void Interact()
    {
        Fishing?.Invoke(this);
    }

    public Fish GetFish()
    {
        _fishAmount--;

        int randomValue = Random.Range(0, CatchChances);

        foreach (var fish in _fishes)
        {
            if (randomValue < fish.CatchChance)
            {
                return fish;
            }

            randomValue -= fish.CatchChance;
        }

        return null;
    }
}
