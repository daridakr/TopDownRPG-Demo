using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Items/Fish")]
public class Fish : Item
{
    [SerializeField] private int _catchChance;

    public int CatchChance => _catchChance;
}
