using UnityEngine;

public class RandomDeploy : MonoBehaviour
{
    [SerializeField] Vector2 BossPosition;

    void Start()
    {
        transform.position = new Vector2(BossPosition.x + Random.Range(-7f, 7f), BossPosition.y + Random.Range(-7f, 7f));
    }
}
