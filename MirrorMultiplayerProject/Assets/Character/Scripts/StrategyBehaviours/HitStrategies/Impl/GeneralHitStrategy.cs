using UnityEngine;

public class GeneralHitStrategy : HitStrategyBase
{
    public GeneralHitStrategy(CharacterBase character) : base(character)
    {

    }

    protected override void StrategyHit(Collision collision)
    {
        if (collision.gameObject.tag == _characterTag)
        {
            ITakeDamageable takeDamageableObject = collision.gameObject.GetComponent<ITakeDamageable>();
            takeDamageableObject.TakeDamage();
        }
    }
}
