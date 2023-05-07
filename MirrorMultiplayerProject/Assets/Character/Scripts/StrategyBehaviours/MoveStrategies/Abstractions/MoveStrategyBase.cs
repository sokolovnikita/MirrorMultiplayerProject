using UnityEngine;

public abstract class MoveStrategyBase : IMovable
{
    protected Animator _characterAnimator;
    protected Rigidbody _characterRigidbody;

    protected const string xMoveDirection = "xMoveDirection";
    protected const string zMoveDirection = "zMoveDirection";

    public MoveStrategyBase(Animator characterAnimator, Rigidbody characterRigidbody) 
    {
        _characterAnimator = characterAnimator;
        _characterRigidbody = characterRigidbody;
    }

    public void Move(float speed, Vector2 direction)
    {
        BaseMove(direction);
        StrategyMove(speed, direction);
    }   

    private void BaseMove(Vector2 direction)
    {
        _characterAnimator.SetFloat(xMoveDirection, direction.x);
        _characterAnimator.SetFloat(zMoveDirection, direction.y);
    }

    abstract public void StrategyMove(float speed, Vector2 direction);
}
