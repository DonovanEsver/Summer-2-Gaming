using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum unitClass
{
    Archer,
    Brawler,
    Giant,
    Minion,
    Swordsman
}
public class Unit : MonoBehaviour
{
    public int cost = 0; // the cost of this. unit
    public unitClass unitClass; // This unit's class   

    // add stats later
}
