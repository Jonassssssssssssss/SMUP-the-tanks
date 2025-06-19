using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] KeyCode _fireButton;
    [SerializeField] float _damage;
    [SerializeField] float _firePower;
    [SerializeField] float _fireRate;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] AudioSource _fireSound;

    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] Transform _muzzleFlashPoint;

    float _reload;

    void Update()
    {
        if (_reload <= 0f)
        {
            if (Input.GetKey(_fireButton))
            {
                Fire();
                _reload = _fireRate;
            }
        }
        else
        {
            _reload -= Time.deltaTime;
        }
    }

    void Fire()
    {
        _fireSound.Play();

        GameObject bullet = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.transform.right * _firePower, ForceMode2D.Impulse);

        bullet.GetComponentInChildren<Projectile>().Damage = _damage;

        GameObject flash = Instantiate(_muzzleFlash, _muzzleFlashPoint.position, _muzzleFlashPoint.rotation);
        flash.transform.SetParent(_muzzleFlashPoint);
    }
}
