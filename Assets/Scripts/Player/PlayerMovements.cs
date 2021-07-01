using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Vector3 _moveDirection;
    private int _jumpCounter = 0;

    private void Start() => _moveDirection = new Vector3();

    public void Move()
    {
        _moveDirection.z = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        transform.Translate(_moveDirection);
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _jumpCounter += 1;
    }

    #region Helpers
    public void ResetJumpCounter() => _jumpCounter = 0;
    public bool CanJumpMore() => _jumpCounter < 1 ? true : false;
    #endregion
}
