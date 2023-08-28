using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 200;
    [SerializeField] private float _jumpForce = 200;

    private Vector2 _input;
    private Rigidbody _rb;
    private bool _jumpRequested;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_input.x * _speed * Time.deltaTime, _rb.velocity.y, _input.y * _speed * Time.deltaTime);
        if (_jumpRequested)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            _jumpRequested = false;
        }
    }
}
