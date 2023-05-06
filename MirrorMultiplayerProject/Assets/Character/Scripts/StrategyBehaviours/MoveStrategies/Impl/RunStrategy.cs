using UnityEngine;

public class RunStrategy : MoveStrategyBase
{
    public RunStrategy(Animator characterAnimator, Rigidbody characterRigidbody) 
        : base(characterAnimator, characterRigidbody)
    {

    }

    public override void Move(float speed, Vector3 direction)
    {
        _characterAnimator.SetFloat(xMoveDirection, direction.x);
        _characterAnimator.SetFloat(zMoveDirection, direction.z);
        _characterRigidbody.velocity = direction * speed;
    }
}
