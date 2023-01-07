using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHealth : EntityHealth
{
    public event Action<float, float> OnHealthUpdate;
    [SerializeField] HealthUI healthUi;

    // GAME DESIGN PART
    [SerializeField] UnityEvent _onEvent;

    private void Start()
    {
        HealthUpdate();
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        HealthUpdate();
    }

    public void HealthUpdate()
    {
        OnHealthUpdate?.Invoke(CurrentHealth, MaxHealth);
    }


    // GAME DESIGN PART -
    [Button("Simulation Activation")]
    private void Simulate ()
    {
        _onEvent.Invoke();
    }

    //FX PART
    public override void LaunchDeathParticle()
    {
        Transform _explosionPosition = transform;
        base.LaunchDeathParticle();
    }
}
