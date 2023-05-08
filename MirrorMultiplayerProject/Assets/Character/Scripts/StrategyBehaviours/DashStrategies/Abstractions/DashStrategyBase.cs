using UnityEngine;

public abstract class DashStrategyBase : IDashable
{
    protected CharacterBase _character;

    public DashStrategyBase(CharacterBase character)
    {
        _character = character;
    }

    public void Dash(float dashTime, Vector2 direction)
    {
        if (!_character.IsDashEnable)
            return;
        StrategyDash(dashTime, direction);
    }

    protected abstract void StrategyDash(float dashTime, Vector2 direction);
}
