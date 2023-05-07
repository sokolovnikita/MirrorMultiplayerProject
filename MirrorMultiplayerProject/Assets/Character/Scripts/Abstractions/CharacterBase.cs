using UnityEngine;

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

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        InitStrategies();
    }

    public float DashCoolDown
    {
        get { return _dashCoolDown; }
    }

    public float DashForce
    {
        get { return _dashForce; }
    }
    
    public float DashTime
    {
        get { return _dashTime; }
    }

    public void Move(Vector2 direction)
    {
        _moveStrategy.Move(_moveSpeed, direction);
    }

    public void Rotate(float rotation)
    {
        _rotateStrategy.Rotate(_rotateSpeed, rotation);
    }

    public void Dash(Vector2 direction)
    {
        _dashStrategy.Dash(_dashForce, direction);
    }

    protected abstract void InitStrategies();  
}
