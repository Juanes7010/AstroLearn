using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectControlador : MonoBehaviour
{
    [SerializeField] GameObject Label;
    [SerializeField] string NameScene;

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;


    private void OnMouseDown()
    {
        EntrarPlaneta();
    }

    public void Start()
    {
        //_myRenderer = GetComponent<Renderer>();
        //ActivarLabel(false);
    }

    public void OnPointerEnterXR()
    {
        ActivarLabel(true);
    }

    public void OnPointerExitXR()
    {
        ActivarLabel(false);
    }

    public void EntrarPlaneta()
    {
        SceneManager.LoadScene(NameScene);
    }

    public void OnPointerClickXR()
    {
        EntrarPlaneta();
    }

    private void ActivarLabel(bool gazedAt)
    {
        if (gazedAt)
        {
            Label.SetActive(true);
        }
        else
        {
            Label.SetActive(false);
        }
    }
}
