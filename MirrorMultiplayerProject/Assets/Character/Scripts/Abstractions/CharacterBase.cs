using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
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

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(0, 0, -1);
        }

        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        _moveStrategy.Move(_speed, direction);
    }

    protected abstract void InitStrategies();
}
