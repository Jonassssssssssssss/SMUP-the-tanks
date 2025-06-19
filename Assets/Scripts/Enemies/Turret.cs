using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform[] _firePoints;
    [SerializeField] GameObject[] _TurretOnSprite;
    [SerializeField] float _damage;
    [SerializeField] float _firePower;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _attackSpeed;
    float reload;
    [SerializeField] AudioSource _fireSound;

    bool PlayerInRange;
    [SerializeField] float _noticeRange;

    Transform _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") PlayerInRange = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player") PlayerInRange = false;
    }

    void Update()
    {
        /*
        float range = Vector3.Distance(_player.position, transform.position);
        if (range <= _noticeRange) PlayerInRange = true;
        else PlayerInRange = false;
        */

        if (PlayerInRange)
        {
            foreach (GameObject t in _TurretOnSprite)
            {
                t.SetActive(true);
            }

            if (reload <= 0)
            {
                Fire();
                reload = _attackSpeed + Random.Range(0f, 0.3f);
            }
            else
            {
                reload -= Time.deltaTime;
            }
        }
        else
        {
            foreach (GameObject t in _TurretOnSprite)
            {
                t.SetActive(false);
            }

            if (reload >= 0) reload -= Time.deltaTime;
        }
    }

    void Fire()
    {
        _fireSound.Play();

        foreach (Transform t in _firePoints)
        {
            GameObject bullet = Instantiate(_projectilePrefab, t.position, t.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(t.right * _firePower, ForceMode2D.Impulse);

            bullet.GetComponentInChildren<Projectile>().Damage = _damage;
        }
    }
}
