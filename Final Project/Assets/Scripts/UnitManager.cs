using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // private static variable to store a single instance of this
    private static UnitManager _instance;

    // a public static reference to this class that can be accessed from anywhere
    public static UnitManager Instance { get { return _instance; } }

    // a list to store all units in the player's army
    public List<GameObject> PlayerUnits;

    // a list to store all units in the enemies army
    public List<GameObject> enemyUnits;

    void Awake()
    {
        // if an instance of this already exits and it isn't this one...
        if (_instance != null && _instance != this)
        {
            // destroy this instance (Ther can only be one)
            Destroy(this.gameObject);
        }
        else
        {
            // set the instance of this script to this instance
            _instance = this;
        }
    } 

    // private constructor
    private UnitManager()
    {
        PlayerUnits = new List<GameObject>();
        enemyUnits = new List<GameObject>();
    }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
