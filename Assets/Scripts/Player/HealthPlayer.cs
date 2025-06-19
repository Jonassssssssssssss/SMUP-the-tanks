using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float MaxHP;
    [SerializeField] float HP;
    [SerializeField] Vector3 _spawnPoint;
    [SerializeField] Slider _HPSlider;

    void Start()
    {
        HP = MaxHP;
        _spawnPoint = transform.position;
        _HPSlider.maxValue = MaxHP;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    public void Heal(float heal)
    {
        HP += heal;
    }

    void Update()
    {
        _HPSlider.value = HP;

        if (HP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        /*
        HP = MaxHP;
        transform.position = _spawnPoint;
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
