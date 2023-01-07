using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int _health = 50;
    [SerializeField] EntityHealth _entityHealth;
    public int RestaureHealth { get { return _health; } private set { _health = value; } }

    public override void Use()
    {
        base.Use();
        _entityHealth.RestaureHealth(RestaureHealth);
        Destroy(gameObject);
    }

 
}
