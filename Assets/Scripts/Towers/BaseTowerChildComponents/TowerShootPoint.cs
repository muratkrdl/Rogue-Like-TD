using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShootPoint : MonoBehaviour
{
    int attackerCount = 0;

    public int AttackerCount
    {
        get => attackerCount;
        set => attackerCount = value;
    }

}
