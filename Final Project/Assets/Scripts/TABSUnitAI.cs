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
        Switch (faction)
        {
            case UnitFaction.Enemy:
            // create a list of all the players units
                break;
            case UnitFaction.Friendly
            // create a list of all the enemies units
                break;
        }
   }
    
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
