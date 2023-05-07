using UnityEngine;

public abstract class DashStrategyBase : IDashable
{
    protected Rigidbody _characterRigidbody;

    public DashStrategyBase(Rigidbody characterRigidbody)
    {
        _characterRigidbody = characterRigidbody;
    }

    public void Dash(float dashTime, Vector2 direction)
    {
        StrategyDash(dashTime, direction);
    }

    protected abstract void StrategyDash(float dashTime, Vector2 direction);
}
