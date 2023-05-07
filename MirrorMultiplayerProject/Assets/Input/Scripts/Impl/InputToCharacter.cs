using System;
using System.Collections;
using UnityEngine;

public class InputToCharacter : MonoBehaviour
{
    [SerializeField] GameObject _controllableGameObject;

    private IControllable _controllableObject;
    private NewInputSystem _newInputSystem;

    private Vector2 _moveDirection = new Vector2();
    private float _rotation = 0;

    private void Awake()
    {
        _newInputSystem = new NewInputSystem();
        _controllableObject = _controllableGameObject.GetComponent<IControllable>();          
    }

    private void OnEnable()
    {
        _newInputSystem.Enable();
    }

    private void OnDisable()
    {
        _newInputSystem.Disable();
    }

    private void Update()
    {
        ReadInput();
        Rotate();           
    }

    private void FixedUpdate()
    {
        Move();
        Dash();
    }

    private void ReadInput()
    {
        _moveDirection = _newInputSystem.Player.Move.ReadValue<Vector2>();
        _rotation = _newInputSystem.Player.Rotate.ReadValue<Vector2>().x;
    }

    private void Move()
    {
        _controllableObject.Move(_moveDirection);
    }

    private void Rotate()
    {
        _controllableObject.Rotate(_rotation);
    }   

    private void Dash()
    {
        if (_newInputSystem.Player.Dash.IsPressed())
        {
            _controllableObject.Dash(_moveDirection);
        }       
    }
}
