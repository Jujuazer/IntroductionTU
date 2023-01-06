using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] int _powerUp = 10;
    [SerializeField] EntityHealth _entityHealth;

    public int ExtendHealth { get { return _powerUp; } private set { _powerUp = value; } }

    public void use()
    {
        _entityHealth.ExtendMaxHealth(ExtendHealth);
    }
}
