using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class EntityGold : MonoBehaviour
{
    public event Action<int> OnGoldUpdate;
    int _nbOfGold = 0;

    private void Awake()
    {
        OnGoldUpdate?.Invoke(_nbOfGold);
    }

    public void AddGold(int gold)
    {
        _nbOfGold += gold;
        OnGoldUpdate?.Invoke(_nbOfGold);
    }
}
