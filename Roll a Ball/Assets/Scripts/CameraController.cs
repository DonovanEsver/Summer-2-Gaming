using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Target GameObject the camera follows")]
    private GameObject _target;

[SerializeField, Tooltip("Distance the camera maintains from the target")]
    private Vector3 _positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        _positionOffset = transform.position - _target.transform.position; // Calculate the distance btwn the cam and target
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Cam position             Player position         distance in btwn
        transform.position = _target.transform.position + _positionOffset;
    }
}
