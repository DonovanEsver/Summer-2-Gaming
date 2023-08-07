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
    [SerializeField, Tooltip("The class of this unit")]
    private unitClass _unitClass; // This unit's class

    [SerializeField, Tooltip("The cost of this unit")]
    private int _cost = 0; // the cost of this. unit

    [SerializeField, Tooltip("The prefab for this unit")]
    private GameObject _unitPrefab;

    [SerializeField, Tooltip("The health of this unit")]
    private float _health;

    [SerializeField, Tooltip("The amount of damage unit")]
    public int _attackDamage;

    [SerializeField, Tooltip("The minimum range this unit can attack")]
    public float _attackRange;

    [SerializeField, Tooltip("The speed this unit moves")]
    private float _moveSpeed;

    [SerializeField, Tooltip("The speed this unit attacks")]
    private int _attackRate;

    public int GetUnitCost()
    {
        // return the cost of this unit to the caller
        return _cost;
    }

    public float GetAttackRange()
    {
        return _attackRange;
    }

    public int GetAttackDamage()
    {
        return _attackDamage;
    }

    public int GetAttackRate()
    {
        return _attackRate;
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }   

}
