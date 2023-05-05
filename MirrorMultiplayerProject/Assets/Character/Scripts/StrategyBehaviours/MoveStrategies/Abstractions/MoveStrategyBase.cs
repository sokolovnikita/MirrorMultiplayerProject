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

    abstract public void Move(float speed, Vector3 direction);
}
