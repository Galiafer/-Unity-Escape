using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _rayPosition;
    [SerializeField] private float _rayDist;

    public bool isGrounded()
    {
        Ray ray = new Ray(_rayPosition.position, Vector3.down);

        if (Physics.Raycast(ray, _rayDist, _layerMask))
            return true;

        return false;
    }
}
