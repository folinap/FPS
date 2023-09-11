using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]private float _sens;
    [SerializeField]private Transform _orientation;

    private float _xRotation;
    private float _yRotation;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sens;
        _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sens;

        _yRotation += _mouseX;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}