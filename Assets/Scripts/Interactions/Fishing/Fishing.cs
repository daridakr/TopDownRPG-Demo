using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    [SerializeField] private FishSchool[] _schools;
    [SerializeField] private float _fishingTime;

    public UnityAction<float> Started;
    public UnityAction<Fish> Fished;
    public UnityAction Finished;

    private void OnEnable()
    {
        foreach (var school in _schools)
        {
            school.Fishing += OnFishing;
        }
    }

    private void OnFishing(FishSchool school)
    {
        if (school.IsEmpty)
        {
            Finished?.Invoke();
        }
        else
        {
            float time = GetRandomFishingTime();
            Started?.Invoke(time);
            StartCoroutine(WaitForFish(school, time));
        }
    }

    private IEnumerator WaitForFish(FishSchool school, float time)
    {
        yield return new WaitForSeconds(time);

        Fish fish = school.GetFish();
        Fished?.Invoke(fish);
    }

    private float GetRandomFishingTime()
    {
        return Random.Range(1, _fishingTime);
    }

    private void OnDisable()
    {
        foreach (var school in _schools)
        {
            school.Fishing += OnFishing;
        }
    }
}
