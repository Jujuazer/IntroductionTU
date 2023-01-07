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

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    [SerializeField] ParticleSystem _deathParticle;
    [SerializeField] Transform _explosionPosition;

    public float CurrentHealth { get; private set; }
    public int MaxHealth { get { return _maxHealth; } private set { _maxHealth = value; }}

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    public void RestaureHealth(int bonus)
    {
        CurrentHealth += bonus;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void ExtendMaxHealth(int bonus)
    {
        MaxHealth += bonus;
    }

    public virtual void TakeDamage (float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            if (_deathParticle != null) { LaunchDeathParticle(); }
            Destroy(gameObject);
        }
    }

    public virtual void LaunchDeathParticle()
    {
        ParticleSystem particleSystem = Instantiate(_deathParticle, _explosionPosition.position, transform.rotation);
        particleSystem.Play();

        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(0.8f);
            particleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
