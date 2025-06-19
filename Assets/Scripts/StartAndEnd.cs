using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartAndEnd : MonoBehaviour
{
    [SerializeField] GameObject _boss;

    [SerializeField] Animator _startScreenAnimator;
    [SerializeField] Animator _fadeToBlackAnimator;

    bool _hasStarted;

    void Update()
    {
        if (!_hasStarted && Input.anyKey)
        {
            _hasStarted = true;
            _startScreenAnimator.SetTrigger("PanAway");
        }

        if (_boss == null)
        {
            StartCoroutine(Victory());
        }
    }

    IEnumerator Victory()
    {
        _fadeToBlackAnimator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("VictoryScreen");
    }
}
