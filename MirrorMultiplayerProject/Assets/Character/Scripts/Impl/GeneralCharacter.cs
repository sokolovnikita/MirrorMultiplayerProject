using UnityEngine;

public class GeneralCharacter : CharacterBase
{
    protected override void InitStrategies()
    {
        _moveStrategy = new RunStrategy(_animator, _rigidbody);
        _rotateStrategy = new GeneralRotateStrategy(_rigidbody);
        _dashStrategy = new GeneralDashStrategy(this);
        _takeDamageStrategy = new GeneralTakeDamageStrategy(this, _renderer);
        _hitStrategy = new GeneralHitStrategy(this);
    }
}
