using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int _health = 50;
    [SerializeField] EntityHealth _entityHealth;
    public int RestaureHealth { get { return _health; } private set { _health = value; } }
    public void use()
    {
        _entityHealth.RestaureHealth(RestaureHealth);
    }
}
