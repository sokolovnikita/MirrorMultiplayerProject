using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CharacterBase : MonoBehaviour, IControllable, ITakeDamageable
{
    [SerializeField] private float _healthPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _dashCoolDown;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashTime;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected Collider _collider;
    protected IMovable _moveStrategy;
    protected IRotateable _rotateStrategy;
    protected IDashable _dashStrategy;

    private bool _isDashEnable = true;
    private bool _isDashing = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        InitStrategies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Character" && _isDashing)
        {
            Debug.Log("HIT PLAYER");
            Hit(collision.gameObject.GetComponent<ITakeDamageable>());
        }
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

    public void TakeDamage()
    {
        _healthPoints -= 1;
        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    private void Hit(ITakeDamageable takeDamageableObject)
    {
        takeDamageableObject.TakeDamage();
    }

    private void Die()
    {
        Destroy(gameObject);
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
