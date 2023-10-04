using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    

    private float _moveSpeed = 200f;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);

       
        
    }
}