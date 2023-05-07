using UnityEngine;
using UnityEngine.EventSystems;

public abstract class RotateStrategyBase : IRotateable
{
    protected Rigidbody _characterRigidbody;

    public RotateStrategyBase(Rigidbody characterRigidbody)
    {
        _characterRigidbody = characterRigidbody;
    }

    public void Rotate(float speed, float rotation)
    {
        StrategyRotate(speed, rotation);
    }

    abstract public void StrategyRotate(float speed, float rotation);
}
