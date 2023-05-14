using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null) //cuando se entra en contacto
        {
            GameManager.Instance.GuardaDatos(); //se guarda la informacion del jugador en ese momento
        }
    }
    #endregion
}
