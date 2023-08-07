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

    // the current target of this unit to attack
    [SerializeField]
    private GameObject _currentTarget;

    private Unit _unit;

    private bool isAttacking = false;

    // list of all enemy units relative to this unit
    public List<GameObject> enemyUnits = new List<GameObject>();
   

   void Awake()
   {
        _agent = GetComponent<NavMeshAgent>();
        _unit = GetComponent<Unit>();

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

   private void Update()
   {
        if (TABSController.gameState == GameState.BattleMode)
        {
            // if a unit is not selected, select one
            if (_currentTarget == null) SelectRandomTarget();

            if (_currentTarget != null) _agent.SetDestination(_currentTarget.transform.position);

            if (!isAttacking)
            {
                StartCoroutine(AttackTarget());
            } 

        }
   }

   private void SelectRandomTarget()
   {
        switch (faction)
        {
            case UnitFaction.Enemy:
                if (UnitManager.Instance.PlayerUnits.Count > 0)
                    _currentTarget = UnitManager.Instance.PlayerUnits[Random.Range(0, UnitManager.Instance.PlayerUnits.Count)].gameObject;
                break;
            case UnitFaction.Friendly:
                if (UnitManager.Instance.enemyUnits.Count > 0)
                    _currentTarget = UnitManager.Instance.enemyUnits[Random.Range(0, UnitManager.Instance.enemyUnits.Count)].gameObject;
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

   public IEnumerator AttackTarget()
   {
        while (_currentTarget != null) 
        {
            float distanceToTarget = Vector3.Distance(transform.position, _currentTarget.transform.position);
            if(distanceToTarget < _unit._attackRange)
            {
                // Deal Damage
            _currentTarget.GetComponent<Unit>().TakeDamage(_unit._attackDamage);
            Debug.Log($"{gameObject.name} attacking {_currentTarget.name}");
            }

            yield return new WaitForSeconds(1 / _unit.GetAttackRate());
        } 

        isAttacking = false; // Reset the flag when the corountine finishes
         
   }

}
