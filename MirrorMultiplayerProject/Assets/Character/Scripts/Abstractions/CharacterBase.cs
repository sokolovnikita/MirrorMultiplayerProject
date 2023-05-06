using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected IMovable _moveStrategy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        InitStrategies();
    }

    public void Move(Vector2 direction)
    {
        _moveStrategy.Move(_speed, direction);
    }

    public void Rotate()
    {

    }

    protected abstract void InitStrategies();  
}
