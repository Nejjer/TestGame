using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _sensivity = 3f;
    private GameObject _camera;
    private Rigidbody _rb;
    private float _rotCamera = 0f;
    //true, ����� ������ �������������
    private bool _blockView = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //gte child Camera
        _camera = transform.GetChild(0).gameObject;
        //Invisible and Locked cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    //vector for movement ������ ��� ������������
    private Vector3 _movementVector
    {
        get
        {
            float _axisX = Input.GetAxis("Horizontal") * _speed;
            float _axisZ = Input.GetAxis("Vertical") * _speed;

            Vector3 _dir = new Vector3(_axisX, 0, _axisZ);
            //������������ ��������� ��� �������� �� ���������
            //Limit diagonally speed 
            return Vector3.ClampMagnitude(_dir, _speed);
        }

    }

    private void Update()
    {
        //Block and UnBlock view
        if (Input.GetKeyDown(KeyCode.Tab) && !_blockView)
        {
            Cursor.lockState = CursorLockMode.None;

            _blockView = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && _blockView)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _blockView = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = transform.TransformDirection(_movementVector);


        //get angle rotate camera
        _rotCamera -= Input.GetAxis("Mouse Y") * _sensivity;
        //limit angle
        if (_rotCamera > 30f)
            _rotCamera = 30f;
        if (_rotCamera < -30f)
            _rotCamera = -30f;
        //set angle ������ ���� ������ �� �������������, �.� ���� ��������� �� �������
        if (!_blockView)
        {
            //rotate player for Y
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensivity, 0);
            //rotate Camera for x
            _camera.transform.localEulerAngles = new Vector3(_rotCamera, 0, 0);
        }

    }
}
