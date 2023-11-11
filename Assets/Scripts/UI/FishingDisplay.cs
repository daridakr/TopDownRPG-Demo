using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingDisplay : WindowDisplay
{
    [SerializeField] private Fishing _fishing;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private Image _fishInfo;
    [SerializeField] private Image _fishImage;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _infoDisplaingTime = 3f;

    private bool _isFishing;
    private float _sliderFillTime;

    private void OnEnable()
    {
        _fishing.Started += OnFishingStart;
        _fishing.Fished += OnFished;
        _fishing.Finished += OnFinished;
    }

    private void OnFishingStart(float time)
    {
        _fishInfo.gameObject.SetActive(false);
        ShowWindow();

        _slider.gameObject.SetActive(true);
        _sliderFillTime = time;
        ResetSlider();
        _isFishing = true;

        _infoText.text = "Fishing...";
    }

    private void Update()
    {
        if (_isFishing)
        {
            _slider.value = Time.time;

            if (_slider.value == 1)
            {
                _isFishing = false;
                _slider.gameObject.SetActive(false);
            }
        }
    }

    private void ResetSlider()
    {
        _slider.minValue = Time.time;
        _slider.maxValue = Time.time + _sliderFillTime;
    }

    private void OnFished(Fish fish)
    {
        _fishInfo.gameObject.SetActive(true);

        _infoText.text = fish.name;
        _fishImage.sprite = fish.Icon;
        _costText.text = fish.Cost.ToString();

        Invoke(nameof(HideWindow), _infoDisplaingTime);
    }

    private void OnFinished()
    {
        _fishInfo.gameObject.SetActive(false);

        if (!IsDisplaing)
        {
            ShowWindow();
        }

        _infoText.text = "There's nothing more to catch";
        Invoke(nameof(HideWindow), _infoDisplaingTime);
    }

    private void OnDisable()
    {
        _fishing.Started -= OnFishingStart;
        _fishing.Fished -= OnFished;
        _fishing.Finished -= OnFinished;
    }
}
