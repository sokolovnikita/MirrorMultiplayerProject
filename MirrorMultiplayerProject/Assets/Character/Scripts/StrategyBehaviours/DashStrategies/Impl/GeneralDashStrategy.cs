using System.Collections;
using UnityEngine;

public class GeneralDashStrategy : DashStrategyBase
{
    public GeneralDashStrategy(Rigidbody characterRigidbody) : base(characterRigidbody)
    {

    }

    protected override void StrategyDash(float dashForce, Vector2 direction)
    {
        Vector3 dashMovement = new Vector3(direction.x, 0, direction.y) * dashForce;
        dashMovement = Quaternion.AngleAxis(_characterRigidbody.transform.eulerAngles.y,
            Vector3.up) * dashMovement;

        _characterRigidbody.AddForce(dashMovement, ForceMode.Impulse);
    }
}
