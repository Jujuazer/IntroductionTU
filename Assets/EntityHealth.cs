using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get { return MaxHealth; } private set{ _maxHealth = value; }}

    private void Awake()
    {
        CurrentHealth = _maxHealth;
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
}
