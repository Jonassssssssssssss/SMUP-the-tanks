using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    Transform _player;
    [SerializeField] Rigidbody2D _rb;

    public bool PlayerInRange;
    [SerializeField] float _noticeRange;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "MainCamera") PlayerInRange = true;
    }

    /*
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "MainCamera") PlayerInRange = false;
    }
    */

    void Update()
    {
        float range = Vector3.Distance(_player.position, transform.position);
        if (range >= _noticeRange) PlayerInRange = false;
        //if (range <= _noticeRange) PlayerInRange = true;
        //else PlayerInRange = false;

        AimAtMouse();
    }

    void AimAtMouse()
    {
        Vector2 lookDir = new Vector2(_player.position.x, _player.position.y) - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
}
