using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum UnitFaction
{
    Friendly,
    Enemy,
}

public class TABSUnitAI : MonoBehaviour
{
   public UnitFaction faction;

   private NavMeshAgent _agent;

    // list of all enemy units relative to this unit
   public List<GameObject> enemyUnits = new List<GameObject>();

   void Awake()
   {
        _agent = GetComponent<NavMeshAgent>();

        // check which faction this enemy belongs too
        switch (faction)
        {
            case UnitFaction.Enemy:
            UnitManager.Instance.enemyUnits.Add(gameObject);
            // create a list of all the players units
                break;
            case UnitFaction.Friendly:
            UnitManager.Instance.PlayerUnits.Add(gameObject);
            // create a list of all the enemies units
                break;
            default: break;
        } 
   }

   private void OnDestroy()
   {
        switch (faction)
        {
            case UnitFaction.Enemy:
                UnitManager.Instance.enemyUnits.Remove(gameObject);
                break;
            case UnitFaction.Friendly:
                UnitManager.Instance.PlayerUnits.Remove(gameObject);
                break;
            default: break;
        } 
   } 
}
