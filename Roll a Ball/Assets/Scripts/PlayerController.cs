using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CharacterController))] //This will attach a CharacterController component to the player automatically when this script os attach
public class PlayerController : MonoBehaviour
{
    // Serialize fields let you edit a private variable in the Unity Editor
    [SerializeField, Tooltip("How fast the player moves")]
    private float _moveSpeed = 5.0f;
    [SerializeField, Tooltip("The force with which the player jumps")]
    private float _jumpForce = 10.0f;
    [SerializeField, Tooltip("The force with which the player is pulled back to the ground")]
    private float _gravity = 10.0f;
    [SerializeField, Tooltip("The CharacterController component on this")]
    private CharacterController _pController;
    private Vector3 _moveDirection; // The current direction the player is moving in // A Vector3 (x, y, z)
    // Start is called before the first frame update
    private void Start()
    {
        _pController = GetComponent<CharacterController>(); // Assigning the var to the CharacterController on this, the player
    }
    private void Update()
    {

        // Stores Player Input
        float _xInput = Input.GetAxis("Horizontal");
        float _zInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(_xInput, 0, _zInput);
        movement = transform.TransformDirection(movement) * _moveSpeed; // Converts the Vector3 from local space to world space
        if (_pController.isGrounded) // If the player is on the ground...
        {
            _moveDirection = movement;
            if (Input.GetButton("Jump")) // If the player hits the space bar while grounded....
            {
                // Make the player jump
                _moveDirection.y = _jumpForce;
            }
        } else // The player is in the air...
        {
            // Pull the player back to the ground with gravity
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        _pController.Move(_moveDirection * Time.deltaTime); // The function call that moves the player based on _moveDirection
    }
}







