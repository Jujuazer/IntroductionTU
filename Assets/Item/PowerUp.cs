using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] int _powerUp = 10;
    [SerializeField] PlayerHealth _entityHealth;

    public int ExtendHealth { get { return _powerUp; } private set { _powerUp = value; } }

    public override void Use()
    {
        base.Use();
        _entityHealth.ExtendMaxHealth(ExtendHealth);
        _entityHealth.HealthUpdate();
        Destroy(gameObject);
    }

    
}
