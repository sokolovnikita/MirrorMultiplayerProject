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
    private bool _isDashEnable = true;
    private bool _isDashing = false;

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
        if (!_isDashing)
        {           
            Rotate();
            Dash();
        }            
    }

    private void FixedUpdate()
    {
        if (!_isDashing)
        {
            Move();
        }         
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
        if (_isDashEnable && _newInputSystem.Player.Dash.IsPressed())
        {
            StartCoroutine(Dashing());
            StartCoroutine(DashCooldDown());           
        }
    }
    
    private IEnumerator Dashing()
    {
        _isDashing = true;
        _controllableObject.Dash(_moveDirection);
        yield return new WaitForSeconds(_controllableObject.DashTime);
        _isDashing = false;
    }

    private IEnumerator DashCooldDown()
    {
        _isDashEnable = false;
        yield return new WaitForSeconds(_controllableObject.DashCoolDown);
        _isDashEnable = true;
    }
}
