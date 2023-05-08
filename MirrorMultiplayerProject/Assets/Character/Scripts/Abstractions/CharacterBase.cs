using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable, ITakeDamageable
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _dashCoolDown;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashTime;
    [SerializeField] private float _hitImmuneTime;
    [SerializeField] private Color _commonColor;
    [SerializeField] private Color _hittedColor;
    [SerializeField] private GameObject _meshGameObject;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected Collider _collider;
    protected Renderer _renderer;
    protected IMovable _moveStrategy;
    protected IRotateable _rotateStrategy;
    protected IDashable _dashStrategy;
    protected ITakeDamageable _takeDamageStrategy;
    protected IHittable _hitStrategy;
    
    private bool _isDashEnable = true;
    private bool _isDashing = false;
    private bool _isHitImmuned = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _renderer = _meshGameObject.GetComponent<Renderer>();
        InitStrategies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _hitStrategy.Hit(collision);
    }

    public int HealthPoints
    {
        get {  return _healthPoints;  }
        set {  _healthPoints = value; }
    }

    public bool IsHitImmuned
    {
        get { return _isHitImmuned; }
        set { _isHitImmuned = value; }
    }

    public float HitImmuneTime
    {
        get { return _hitImmuneTime; }
    }
    
    public Color CommonColor
    {
        get { return _commonColor; }
    }

    public Color HittedColor
    {
        get { return _hittedColor; }
    }

    public bool IsDashEnable
    {
        get { return _isDashEnable; }
        set { _isDashEnable = value; }
    }

    public bool IsDashing
    {
        get { return _isDashing; }
        set { _isDashing = value; }
    }

    public float DashTime
    {
        get { return _dashTime; }
    }

    public float DashCoolDown
    {
        get { return _dashCoolDown; }
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
        _dashStrategy.Dash(_dashForce, direction);
    }

    public void TakeDamage()
    {
        _takeDamageStrategy.TakeDamage();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void InitStrategies();    
}
