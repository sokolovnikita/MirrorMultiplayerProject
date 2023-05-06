using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private CharacterBase _character;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;
    [SerializeField] private float _xRotationOffset;
    [SerializeField] private float _yRotationOffset;
    [SerializeField] private float _zRotationOffset;

    private void Update()
    {
        FollowPosition();
        FollowRotation();
    }

    private void FollowPosition()
    {
        Vector3 positionOffset = new Vector3(_xOffset, _yOffset, _zOffset);
        transform.position = _character.transform.TransformPoint(positionOffset);
    }

    private void FollowRotation()
    {
        Vector3 rotationOffset = new Vector3(_xRotationOffset, _character.transform.eulerAngles.y
            + _yRotationOffset, _zRotationOffset);
        transform.rotation = Quaternion.Euler(rotationOffset);
    }
}
