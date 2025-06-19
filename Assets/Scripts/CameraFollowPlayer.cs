using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] GameObject _bossHPBar;
    [SerializeField] Vector3 _bossLocation;

    bool _bossTime;

    void Update()
    {
        if (!_bossTime) transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        else transform.position = _bossLocation;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Boss")
        {
            _bossTime = true;
            _bossHPBar.SetActive(true);
        }
    }
}
