using UnityEngine;

public abstract class HitStrategyBase : IHittable
{
    protected CharacterBase _character;
    protected const string _characterTag = "Character";

    public HitStrategyBase(CharacterBase character)
    {
        _character = character;
    }

    public void Hit(Collision collision)
    {
        if (!_character.IsDashing)
            return;
        StrategyHit(collision);
    }

    protected abstract void StrategyHit(Collision collision);
}
