using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _playerGold;

    private void Awake()
    {
        _playerGold.OnGoldUpdate += UpdateGoldState;
    }

    private void OnDestroy()
    {
        _playerGold.OnGoldUpdate -= UpdateGoldState;
    }

    private void UpdateGoldState (int gold)
    {
        _text.text = $"Gold : {gold}";
    }
}
