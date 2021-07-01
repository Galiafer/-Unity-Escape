using UnityEngine;
using UnityEngine.Events;

public class DangerZone : MonoBehaviour
{
    public static UnityAction OnPlayerEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
            OnPlayerEnter?.Invoke();
    }
}
