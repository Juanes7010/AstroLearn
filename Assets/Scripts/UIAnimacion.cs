using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimacion : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    float delay;

    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    RectTransform target;

    [SerializeField]
    Vector3 startPoint;
    [SerializeField]
    Vector3 finalPoint;
    [SerializeField]
    GameObject Menu;


    [ContextMenu("StartAnimation")]
    public void StartAnimation()
    {
        if (Menu.activeInHierarchy)
        {
            FadeOut();
            Invoke("Desactivar", 2f);
        }
        else
        {
            Menu.SetActive(true);
            FadeIn();
        }
    }

    public void ScaleAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleInCoroutine(startPoint, finalPoint));
    }

    [ContextMenu("Fade in")]
    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(startPoint, finalPoint));
    }
    [ContextMenu("Fade out")]
    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(finalPoint, startPoint));
    }
    IEnumerator FadeInCoroutine(Vector3 a, Vector3 b)
    {
        Vector3 startPoint = a;
        Vector3 finalPoint = b;
        float elapsed = 0;
        while (elapsed <= delay)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        while (elapsed <= duration)
        {
            float percentage = elapsed / duration;
            float curvePercentage = animationCurve.Evaluate(percentage);
            elapsed += Time.deltaTime;
            Vector3 currentPosition = Vector3.LerpUnclamped(startPoint, finalPoint, curvePercentage);
            target.anchoredPosition = currentPosition;
            yield return null;
        }

        target.anchoredPosition = finalPoint;
    }
    void Desactivar()
    {
        Menu.SetActive(false);
    }

    IEnumerator ScaleInCoroutine(Vector3 a, Vector3 b)
    {
        Vector3 startPoint = a;
        Vector3 finalPoint = b;
        float elapsed = 0;
        while (elapsed <= delay)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0;
        while (elapsed <= duration)
        {
            float percentage = elapsed / duration;
            float curvePercentage = animationCurve.Evaluate(percentage);
            elapsed += Time.deltaTime;
            Vector3 currentPosition = Vector3.LerpUnclamped(startPoint, finalPoint, curvePercentage);
            target.localScale = currentPosition;
            yield return null;
        }

        target.localScale = finalPoint;
    }
}
