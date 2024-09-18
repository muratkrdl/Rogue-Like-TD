using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShootPoint : MonoBehaviour
{
    public int attackerCount = 0;

    public int AttackerCount
    {
        get
        {
            return attackerCount;
        }
        set
        {
            attackerCount = value;
        }
    }

}
