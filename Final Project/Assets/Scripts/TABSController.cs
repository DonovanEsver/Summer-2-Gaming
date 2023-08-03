using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    RecruitMode,
    DeleteMode,
    BattleMode,
}

public class TABSController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    // list of all units currently in the player's army on the battlefield
    public List<GameObject> spawnedUnits = new List<GameObject>();

    [Tooltip("A list of all unit gameobjects the player is able to buy")]
    public GameObject[] unitArray;

    [SerializeField, Tooltip("The Current unit that is pending to be placed in the game world")]
    private GameObject _pendingUnit;

    [SerializeField]
    private Vector3 _pos; // the current location of the mosue?

    private RaycastHit _hit; // the current object we click on with our mouse

    [SerializeField, Tooltip("The layers the mouse can place units on")]
    private LayerMask _interactableLayers;

    [SerializeField, Tooltip("The layer our friendly units sit on")]
    private LayerMask _friendlyUnitLayers;

    public int startingMoney; // the amount of money the player has to spend each level

    public TMP_Text moneyText;

    // Start is called before the first frame update

    public static GameState gameState = GameState.RecruitMode;
    void Start()
    {
        gameState = GameState.RecruitMode;
        moneyText.text = startingMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.RecruitMode)
        {
             // if the pending unit is not empty/ if we have a unit wating to be placed in game...
            if(_pendingUnit != null)
            {
                // set the position of the unit to the position of the mous
                _pendingUnit.transform.position = _pos;

                // if the player left clicks
                if(Input.GetMouseButtonDown(0))
                {
                    // place our units in the world
                    PlaceUnit();
                }
            }
        }

        if (gameState == GameState.DeleteMode)
        {
            // if the player left clicks
            if (Input.GetMouseButtonDown(0))
            {
                // shoot out a ray to check if we hit something
                Ray deleteRay = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(deleteRay, out _hit, Mathf.Infinity, _friendlyUnitLayers))
                {
                    Debug.Log($"We Hit " + _hit.collider.name);

                    // store the unit gameObject
                    GameObject unitToDelete = _hit.collider.gameObject;

                    DeleteUnit(unitToDelete);
                } else RecruitMode();
            }
        }
    }

        //Then delete that unit

    void FixedUpdate()
    {
        // every frame, shoot out a ray from our mouse and storing it in a varaible
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        // If the ray from our mouae hit an object within the interactable layers...
        if(Physics.Raycast(ray, out _hit, 10000, _interactableLayers))
        {
            // store current position of where that ray hit
            _pos = _hit.point;
        } 
    }

    public void SelectUnit(int index)
    {
        // if the player can afford the unit they are attempting to buy...
        if(startingMoney >= unitArray[index].GetComponent<Unit>().cost)
        {
            // spawn unit for the player to place
            _pendingUnit = Instantiate(unitArray[index], _pos, transform.rotation);


            // subtract unit cost from players money
            startingMoney -= unitArray[index].GetComponent<Unit>().cost;


            // Update money text
            moneyText.text = startingMoney.ToString();

        } else Debug.LogErrorFormat("Not enough money. ");
    }

    public void PlaceUnit()
    {
        spawnedUnits.Add(_pendingUnit);
        _pendingUnit = null;
    }

    public void DeleteUnit(GameObject unitToDelete)
    {
        // refund the player $ for deleting unit
        startingMoney += unitToDelete.GetComponent<Unit>().cost;

        // update money text
        moneyText.text = startingMoney.ToString();

        // Remove unit from spawn list
        spawnedUnits.Remove(unitToDelete);

        // delete the unit
        Destroy(unitToDelete);

        RecruitMode();
    }

    public void ClearUnits()
    {
        // Create a temp copy of unit list
        List<GameObject> unitsToRemove = new List<GameObject>(spawnedUnits);

        // loop through all friendly units
        foreach (GameObject unit in unitsToRemove)
        {
            DeleteUnit(unit);
        }

        spawnedUnits.Clear();
    }

    public void DeleteMode()
    {
        gameState = GameState.DeleteMode;
    }

    public void RecruitMode()
    {
        gameState = GameState.RecruitMode;
    }

    public void BattleMode()
    {
        gameState = GameState.BattleMode;
    }
}




   