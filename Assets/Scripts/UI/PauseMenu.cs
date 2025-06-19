using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    Animator _animator;
    [SerializeField] bool _pauseReady;

    void Start()
    {
        _pauseReady = true;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pauseReady)
        {
            _pauseReady = false;
            SwitchPause();
        }
    }

    public void SwitchPause()
    {
        StartCoroutine(RealSwitchPause());
    }

    IEnumerator RealSwitchPause()
    {
        if (Time.timeScale == 1f)
        {
            _animator.SetBool("pause", true);
            yield return new WaitForSeconds(0.5f);
            _pauseReady = true;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            _animator.SetBool("pause", false);
            yield return new WaitForSeconds(0.5f);
            _pauseReady = true;
        }
    }
}
