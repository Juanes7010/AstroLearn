using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroduccionAR : MonoBehaviour
{
    public string NameScene;
    [SerializeField] float Tiempo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("OpenLevel");
    }
    IEnumerator OpenLevel()
    {
        yield return new WaitForSecondsRealtime(Tiempo);
        SceneManager.LoadScene(NameScene);
    }
}
