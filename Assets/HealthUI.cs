using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth.OnHealthUpdate += UpdateSlider;
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthUpdate -= UpdateSlider;
    }

    private void UpdateSlider(float newHealthValue, float newMaxHealth)
    {
        _slider.value = newHealthValue;
        _slider.maxValue = newMaxHealth;
        _text.text = $"{newHealthValue} / {newMaxHealth}";
    }

}
