using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    int _gold = 1;
    [SerializeField] EntityGold _entityGold;
    public int Money { get { return _gold; } private set { _gold = value; } }
    public void use()
    {
        _entityGold.AddGold(Money);
        Destroy(gameObject);
    }
}
