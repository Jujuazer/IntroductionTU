using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticulePop : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;

    [SerializeField] CinemachineImpulseSource _impulse;

    [SerializeField] UnityEvent _myEvent;

    [SerializeField] public event Action OnBlabla;

    private void Start()
    {
        //_playerMove.OnStartMove += _playerMove_OnStartMove;
        //_playerMove.OnHealthUpdate += EXPLOISION;
    }

    private void EXPLOISION(int obj)
    {
        _myEvent.Invoke();
        _impulse.GenerateImpulseWithVelocity(Vector3.one * 10);
    }

    private void _playerMove_OnStartMove()
    {
        throw new System.NotImplementedException();
    }
}
