using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] float _duration;
    [SerializeField] GameObject _destructionEffectPrefab;

    void Start()
    {
        Destroy(gameObject, _duration);
    }

    void OnDestroy()
    {
        if (_destructionEffectPrefab != null) Instantiate(_destructionEffectPrefab, transform.position, Quaternion.identity);
    }
}
