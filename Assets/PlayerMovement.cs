using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;


    private Vector2 _input;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_input.x * _speed * Time.deltaTime, _rb.velocity.y, _input.y * _speed * Time.deltaTime);
    }
}
