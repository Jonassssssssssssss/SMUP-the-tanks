using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] float _heal;
    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _audio.Play();
            collider.GetComponent<HealthPlayer>().Heal(_heal);
            Destroy(gameObject,1f);
        }
    }
}
