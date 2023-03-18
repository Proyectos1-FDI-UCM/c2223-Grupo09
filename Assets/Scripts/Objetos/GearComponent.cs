using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearComponent : MonoBehaviour
{
    [SerializeField]
    private AudioClip _gearSound;
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)  //si el engranaje es recogido por el jugador
        {
            AudioControler.Instance.PlaySound(_gearSound);
            Destroy(gameObject);                                               //se "destruye" el engranaje
            GameManager.Instance.OnPickGear();                                 //se llama al metodo que lleva el contador de engranajes
        } 
    }
    #endregion

}
