using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    int _nbOfGold = 0;
    //public int NbOfGold { get { return _nbOfGold; } set { _nbOfGold = value; }}
    public void AddGold(int gold)
    {
        _nbOfGold += gold;
    }
}
