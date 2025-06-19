using UnityEngine;
using UnityEngine.UI;

public class HPEnemy : MonoBehaviour
{
    [SerializeField] float HP;
    [SerializeField] Slider _hpSlider;

    void Start()
    {
        if (_hpSlider != null) _hpSlider.maxValue = HP;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    void Update()
    {
        if (_hpSlider != null) _hpSlider.value = HP;

        if (HP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
