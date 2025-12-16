using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float Segundos;
    [SerializeField] GameObject gameObject;
    void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(Segundos);
        Destroy(gameObject);
    }
}
