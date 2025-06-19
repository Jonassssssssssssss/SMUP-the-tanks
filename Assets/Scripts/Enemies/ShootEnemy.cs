using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackInfo
{
    public Transform[] _firePoints;
    public float _damage;
    public float _firePower;
    public GameObject _projectilePrefab;
    public float _attackSpeed;
    public AudioSource _fireSound;

    public float _repeatSpeed;
    public int _repeatAttack = 1;
}

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] AttackInfo[] _attackPattern;

    [SerializeField] EnemyAim EA;

    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] Transform[] _muzzleFlashPoints;

    bool _attackPatternReady;

    void Start()
    {
        _attackPatternReady = true;
    }

    void Update()
    {
        if (_attackPatternReady)
        {
            if (EA.PlayerInRange)
            {
                _attackPatternReady = false;
                StartCoroutine(AttackPattern());
            }
        }
    }

    void Fire(Transform[] firepoints, float damage, float firePower, GameObject prefab, AudioSource sound)
    {
        sound.Play();

        foreach (Transform t in firepoints)
        {
            GameObject bullet = Instantiate(prefab, t.position, t.rotation);//t.rotation);
            
            if (bullet.GetComponent<Rigidbody2D>())
            {
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(t.right * firePower, ForceMode2D.Impulse);
            }

            if (bullet.GetComponentInChildren<Projectile>()) bullet.GetComponentInChildren<Projectile>().Damage = damage;
        }

        foreach (Transform t in _muzzleFlashPoints)
        {
            GameObject flash = Instantiate(_muzzleFlash, t.position, t.rotation);
            flash.transform.SetParent(t);
        }
    }

    IEnumerator AttackPattern()
    {
        yield return new WaitForSeconds(1f);

        foreach (AttackInfo attack in _attackPattern)
        {
            for (int i = 0; i < attack._repeatAttack; i++)
            {
                Fire(attack._firePoints, attack._damage, attack._firePower, attack._projectilePrefab, attack._fireSound);
                yield return new WaitForSeconds(attack._repeatSpeed);
            }
            yield return new WaitForSeconds(attack._attackSpeed + Random.Range(0f, 0.3f));
        }

        yield return new WaitForSeconds(0.1f);

        _attackPatternReady = true;
    }
}
