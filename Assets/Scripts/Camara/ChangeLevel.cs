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
            GameManager.Instance.GuardaDatos();
            SceneManager.LoadScene("NIVELES");
        }
        else if (ControladorDeSalas.Instance.Sección == 2)
        {
            GameManager.Instance.GuardaDatos();
            SceneManager.LoadScene("INTERMEDIOS");
        }
        else if (ControladorDeSalas.Instance.Sección == 3)
        {
            GameManager.Instance.GuardaDatos();
            SceneManager.LoadScene("DIFICILES");
        }
        else if (ControladorDeSalas.Instance.Sección == 4)
        {
            GameManager.Instance.GuardaDatos();
            SceneManager.LoadScene("Boss final");
        }
    }
    #endregion
}