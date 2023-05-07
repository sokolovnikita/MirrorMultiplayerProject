using UnityEngine;

public class RunStrategy : MoveStrategyBase
{
    public RunStrategy(Animator characterAnimator, Rigidbody characterRigidbody) 
        : base(characterAnimator, characterRigidbody)
    {

    }

    public override void StrategyMove(float speed, Vector2 direction)
    {    
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
        newDirection = Quaternion.AngleAxis(_characterRigidbody.transform.eulerAngles.y, 
            Vector3.up) * newDirection;
        _characterRigidbody.velocity = newDirection * speed;
    }
}
