using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected IMovable _moveStrategy;
    protected IRotateable _rotateStrategy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        InitStrategies();
    }

    public void Move(Vector2 direction)
    {
        _moveStrategy.Move(_moveSpeed, direction);
    }

    public void Rotate(float rotation)
    {
        _rotateStrategy.Rotate(_rotateSpeed, rotation);
    }

    protected abstract void InitStrategies();  
}
