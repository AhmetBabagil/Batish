using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillClimbRacingDriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTire;
    [SerializeField] private Rigidbody2D _backTire;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed=150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput;
    private void Update()
    {
      //  _moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(_moveInput);
    }

    private void FixedUpdate()
    {
        _frontTire.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTire.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void SETMOVEINPUTTO1()
    {
        _moveInput = 1;
    }
    public void SETMOVEINPUTTONEGATIVE1()
    {
        _moveInput = -1;
    }
    public void SETMOVEINPUTTOZERO()
    {
        _moveInput = 0;
    }
}
