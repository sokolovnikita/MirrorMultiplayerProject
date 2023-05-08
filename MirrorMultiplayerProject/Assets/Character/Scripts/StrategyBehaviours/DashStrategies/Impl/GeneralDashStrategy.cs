using System.Collections;
using UnityEngine;

public class GeneralDashStrategy : DashStrategyBase
{
    private Rigidbody _characterRigidbody;

    public GeneralDashStrategy(CharacterBase character) : base(character)
    {
        _characterRigidbody = character.GetComponent<Rigidbody>();
    }

    protected override void StrategyDash(float dashForce, Vector2 direction)
    {
        StartDash(dashForce, direction);
        _character.StartCoroutine(AfterDashStart());
        _character.StartCoroutine(DashCoolDown());
    }

    private void StartDash(float dashForce, Vector2 direction)
    {
        Vector3 dashMovement = new Vector3(direction.x, 0, direction.y) * dashForce;
        dashMovement = Quaternion.AngleAxis(_characterRigidbody.transform.eulerAngles.y,
            Vector3.up) * dashMovement;

        _characterRigidbody.AddForce(dashMovement, ForceMode.Impulse);
    }

    private IEnumerator AfterDashStart()
    {
        _character.IsDashing = true;
        yield return new WaitForSeconds(_character.DashTime);
        _character.IsDashing = false;
    }

    private IEnumerator DashCoolDown()
    {
        _character.IsDashEnable = false;
        yield return new WaitForSeconds(_character.DashCoolDown);
        _character.IsDashEnable = true;
    }
}
