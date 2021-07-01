using UnityEngine;

public class DangerZoneMoving : MonoBehaviour
{
    [SerializeField] private float _timeToStart = 5f;

    private const float SPEED_REDUCER = 1.5f;

    private float _speed = 0f;
    private float _timer = 0f;

    private void Update()
    {
        if (IsTimerEnd())
            Move();
    }

    private void Move()
    {
        _speed += Time.deltaTime / SPEED_REDUCER;

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private bool IsTimerEnd()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToStart)
            return true;

        return false;
    }
}
