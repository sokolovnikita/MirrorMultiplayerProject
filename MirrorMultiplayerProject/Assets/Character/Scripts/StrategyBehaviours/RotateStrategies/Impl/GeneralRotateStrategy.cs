using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRotateStrategy : RotateStrategyBase
{
    public GeneralRotateStrategy(Rigidbody characterRigidbody) : base(characterRigidbody)
    {

    }

    public override void StrategyRotate(float speed, float rotation)
    {
        _characterRigidbody.transform.Rotate(new Vector3(0, rotation * speed * Time.deltaTime, 0));
    }
}
