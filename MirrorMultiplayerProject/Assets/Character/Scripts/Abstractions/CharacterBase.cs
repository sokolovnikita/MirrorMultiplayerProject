using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CharacterBase : MonoBehaviour, IControllable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _dashCoolDown;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashTime;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected IMovable _moveStrategy;
    protected IRotateable _rotateStrategy;
    protected IDashable _dashStrategy;

    private bool _isDashEnable = true;
    private bool _isDashing = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        InitStrategies();
    }

    public void Move(Vector2 direction)
    {
        if (!_isDashing)
        {
            _moveStrategy.Move(_moveSpeed, direction);
        }       
    }

    public void Rotate(float rotation)
    {
        if (!_isDashing)
        {
            _rotateStrategy.Rotate(_rotateSpeed, rotation);
        }      
    }

    public void Dash(Vector2 direction)
    {
        if (_isDashEnable)
        {
            StartCoroutine(Dashing(direction));
            StartCoroutine(DashCoolDown());
        }
    }

    private IEnumerator Dashing(Vector2 direction)
    {
        _isDashing = true;
        _dashStrategy.Dash(_dashForce, direction);
        yield return new WaitForSeconds(_dashTime);
        _isDashing = false;
    }

    private IEnumerator DashCoolDown()
    {
        _isDashEnable = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _isDashEnable = true;
    }

    protected abstract void InitStrategies();  
}
