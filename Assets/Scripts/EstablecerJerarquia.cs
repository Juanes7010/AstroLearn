using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstablecerJerarquia : MonoBehaviour
{
    [SerializeField]
    Canvas Canva1;
    [SerializeField]
    Canvas Canva2;

    public void CambiarJerarquia()
    {
        Canva1.sortingOrder = 1;
        Canva2.sortingOrder = 0;
    }
}
