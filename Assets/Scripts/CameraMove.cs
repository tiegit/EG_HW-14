using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothness = 5f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _smoothness * Time.deltaTime);
    }
}