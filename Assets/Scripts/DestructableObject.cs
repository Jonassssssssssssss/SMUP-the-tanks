using UnityEngine;
using System.Collections;

public class DestructableObject : MonoBehaviour
{
    [SerializeField] float HP = 10f;

    public void TakeDamage(float damage)
    {
        DamageFlash();
        HP -= damage;

        if (HP <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void DamageFlash()
    {
        Debug.Log("flash");
    }
}
