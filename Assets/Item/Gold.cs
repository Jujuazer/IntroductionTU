using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    int _gold = 1;
    [SerializeField] EntityGold _entityGold;
    public int Money { get { return _gold; } private set { _gold = value; } }

    public override void Use()
    {
        base.Use();
        _entityGold.AddGold(Money);
        Destroy(gameObject);
    }
}
