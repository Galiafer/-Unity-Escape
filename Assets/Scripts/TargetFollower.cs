using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotationOffset;
    [SerializeField] private float _smoothForce;

    private void Start() => transform.rotation = Quaternion.Euler(_rotationOffset);

    private void LateUpdate() => transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothForce * Time.deltaTime);
}
