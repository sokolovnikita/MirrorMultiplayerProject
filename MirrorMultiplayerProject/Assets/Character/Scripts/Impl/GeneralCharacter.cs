using UnityEngine;

public class GeneralCharacter : CharacterBase
{
    protected override void InitStrategies()
    {
        _moveStrategy = new RunStrategy(_animator, _rigidbody);
    }
}
