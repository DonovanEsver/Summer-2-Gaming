using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TABSController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [Tooltip("A list of all unit gameobjects the player is able to buy")]
    public GameObject[] unitArray;

    [SerializeField, Tooltip("The Current unit that is pending to be placed in the game world")]
    private GameObject _pendingUnit;

    [SerializeField]
    private Vector3 _pos; // the current location of the mosue?

    private RaycastHit _hit; // the current object we click on with our mouse

    [SerializeField, Tooltip("The layers the mouse can place units on")]
    private LayerMask _interactableLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        _pendingUnit = Instantiate(unitArray[index], _pos, transform.rotation);
    }

    public void PlaceUnit()
    {
        _pendingUnit = null;
    }

}




   