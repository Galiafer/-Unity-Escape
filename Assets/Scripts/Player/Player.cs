using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovements _playerMovements;
    [SerializeField] private GroundChecker _groundChecker;

    public static UnityAction OnPlayerDie;

    private void OnEnable() => DangerZone.OnPlayerEnter = Finish.OnFinish += Disappear;

    private void OnDisable() => DangerZone.OnPlayerEnter = Finish.OnFinish -= Disappear;

    private void Update()
    {
        _playerMovements.Move();

        #region Regular Jump
        if (Input.GetKeyDown(KeyCode.W) && _groundChecker.isGrounded())
            _playerMovements.Jump();
        #endregion

        #region Double Jump
        if (Input.GetKeyDown(KeyCode.W) && _playerMovements.CanJumpMore() && !_groundChecker.isGrounded())
            _playerMovements.Jump();
        #endregion

        #region Jump Counter Reseter
        if (_groundChecker.isGrounded())
            _playerMovements.ResetJumpCounter();
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish finish))
            Finish.OnFinish?.Invoke();

        if (other.TryGetComponent(out Sea sea))
        {
            OnPlayerDie?.Invoke();
            Disappear();
        }
    }


    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
