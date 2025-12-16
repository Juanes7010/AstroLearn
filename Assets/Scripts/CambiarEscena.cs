using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string NameScene;
    [SerializeField] Animator transitionCamera;
    [SerializeField] Animator transitionPlayer;
    [SerializeField] Animator transitionSound;
    public void Openlevel()
    {
        SceneManager.LoadScene(NameScene);
    }

    public void Transition()
    {
        StartCoroutine("TransitionEscene");
    }

    IEnumerator TransitionEscene()
    {
        transitionPlayer.SetBool("Iniciar", true);
        transitionSound.SetBool("Iniciar", true);
        yield return new WaitForSecondsRealtime(1f);
        transitionCamera.SetBool("Iniciar", true);
        yield return new WaitForSecondsRealtime(1f);
        Openlevel();
    }
}
