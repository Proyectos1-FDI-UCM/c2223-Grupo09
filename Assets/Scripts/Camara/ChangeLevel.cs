using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private InputComponent _myInputComponent;
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            _myInputComponent = collision.GetComponent<InputComponent>();
            _myInputComponent.enabled = false;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Change();
    }
    private void Change()
    {
        _myInputComponent.enabled = true;
        if (ControladorDeSalas.Instance.Sección == 1)
        {
            SceneManager.LoadScene("NIVELES");
        }
        else if (ControladorDeSalas.Instance.Sección == 2)
        {
            SceneManager.LoadScene("INTERMEDIOS");
        }
        else if (ControladorDeSalas.Instance.Sección == 3)
        {
            SceneManager.LoadScene("DIFICILES");
        }
        else if (ControladorDeSalas.Instance.Sección == 4)
        {
            SceneManager.LoadScene("Boss final");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ControladorDeSalas.Instance.Sección);
    }

}