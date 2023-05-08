using UnityEngine;

public abstract class TakeDamageStrategyBase : ITakeDamageable
{
    protected CharacterBase _character;
    protected Renderer _renderer;

    public TakeDamageStrategyBase(CharacterBase character, Renderer renderer)
    {
        _character = character;
        _renderer = renderer;
    }

    public void TakeDamage() 
    {
        StrategyTakeDamage();
    }

    protected abstract void StrategyTakeDamage();
}
