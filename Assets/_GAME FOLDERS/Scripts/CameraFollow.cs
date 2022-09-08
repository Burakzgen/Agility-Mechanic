using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _lerpSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y, _targetTransform.position.z + _offset.z), _lerpSpeed * Time.deltaTime);
    }
}
