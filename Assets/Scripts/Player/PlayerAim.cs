using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Camera _cam;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Transform _head;

    Vector2 _mousePos;

    void Start()
    {
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        AimAtMouse();
    }

    void AimAtMouse()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = _mousePos - new Vector2(_head.position.x, _head.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        _head.rotation = q;// Quaternion.Slerp(_head.rotation, q, Time.deltaTime * 4f);
        //_rb.rotation = angle;
    }
}
