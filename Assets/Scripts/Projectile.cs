using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    [SerializeField] float _duration = 5f;
    [SerializeField] bool _enemyBullet;

    [SerializeField] GameObject _parent;

    [SerializeField] bool _resetRotation;

    void Start()
    {
        if (_resetRotation) transform.rotation = Quaternion.identity;
        Destroy(gameObject, _duration);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!_enemyBullet)
        {
            if (collider.gameObject.GetComponent<HPEnemy>())
            {
                collider.gameObject.GetComponent<HPEnemy>().TakeDamage(Damage);
            }
            else if (collider.gameObject.GetComponent<DestructableObject>())
            {
                collider.gameObject.GetComponent<DestructableObject>().TakeDamage(Damage);
            }
        }
        else
        {
            if (collider.gameObject.GetComponent<HealthPlayer>())
            {
                collider.gameObject.GetComponent<HealthPlayer>().TakeDamage(Damage);
            }
        }

        Destroy(_parent);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "MainCamera") Destroy(_parent);
    }
}
