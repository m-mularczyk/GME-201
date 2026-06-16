using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;

    [SerializeField]
    private float _yawInput = 0;

    [SerializeField]
    private ParticleSystem _spaceDustParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed+=4;
            if (_currentSpeed > 16)
            {
                _currentSpeed = 16;
            }

            //Change speed of dust particles
            var main = _spaceDustParticleSystem.main;
            main.startSpeed = _currentSpeed * 20f / 3f;

        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed-=4;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }

            //Change speed of dust particles
            var main = _spaceDustParticleSystem.main;
            main.startSpeed = _currentSpeed * 20f / 3f;

        }//decrease speed

        // Additional code for yaw movement
        if (Input.GetKey(KeyCode.Q))
        {
            // Yaw left
            _yawInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            // Yaw right
            _yawInput = 1;
        }
        else
        {
            _yawInput = 0;
        }

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(_vertical * 0.2f, _yawInput * 0.1f, -_horizontal * 0.5f), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }
}
