using UnityEngine;

public interface IControllable
{
    public void Move(Vector2 direction);

    public void Rotate(float rotation);

    public void Dash(Vector2 direction);
}
