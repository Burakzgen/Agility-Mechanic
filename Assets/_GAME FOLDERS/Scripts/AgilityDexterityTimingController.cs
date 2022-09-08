using UnityEngine;
using System.Collections;

public class AgilityDexterityTimingController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _forwardHop = 5f;
    [SerializeField] private float _upHop = 5f;

    [SerializeField] private LayerMask _layer;
    private Vector3 _rayToWorldPos;

    private float _screenBoundsX;
    private float _playerSizeX;

    [SerializeField] private float _lerpSpeed = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _screenBoundsX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        _playerSizeX = GetComponent<MeshRenderer>().bounds.size.x;
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out RaycastHit hit, 500f, _layer))
        {
            _rayToWorldPos = new Vector3(Mathf.Clamp(hit.point.x, _screenBoundsX + _playerSizeX, -_screenBoundsX - _playerSizeX), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, _rayToWorldPos, _lerpSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        _rb.AddForce(transform.up * _upHop + transform.forward * _forwardHop, ForceMode.Impulse);
    }
}
