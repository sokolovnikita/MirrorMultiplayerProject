using System.Collections;
using UnityEngine;

public class GeneralTakeDamageStrategy : TakeDamageStrategyBase
{
    private Rigidbody _characterRigidbody;

    public GeneralTakeDamageStrategy(CharacterBase character, Renderer renderer) 
        : base(character, renderer)
    {
        _characterRigidbody = character.GetComponent<Rigidbody>();
    }

    protected override void StrategyTakeDamage()
    {
        if (_character.IsHitImmuned)
            return;

        TakeHit();
        _character.StartCoroutine(AfterTakeHit());
    }

    private void TakeHit()
    {
        _renderer.material.color = _character.HittedColor;
        _characterRigidbody.velocity = new Vector3();
        _character.HealthPoints -= 1;
        _character.IsHitImmuned = true;
        if (_character.HealthPoints <= 0)
        {
            _character.Die();
        }
    }

    private IEnumerator AfterTakeHit()
    {
        yield return new WaitForSeconds(_character.HitImmuneTime);
        _renderer.material.color = _character.CommonColor;
        _character.IsHitImmuned = false;
    }
}
