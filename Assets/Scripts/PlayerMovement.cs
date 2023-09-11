using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float _moveSpeed;
    [SerializeField]private Transform _orientation;
    [SerializeField]private Rigidbody _playerRigidbody;

    private Vector3 _moveDirection;
    private float _horizontalInput;
    private float _verticalInput;

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _playerRigidbody.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
    }



}