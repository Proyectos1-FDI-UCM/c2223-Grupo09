using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    [SerializeField]
    private AudioClip _botiquinSound;
    private PlayerLifeComponent _myPlayerLifeComponent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)                       //si el botiquín entra en contacto con el jugador
        {
            AudioControler.Instance.PlaySound(_botiquinSound);
            _myPlayerLifeComponent = collision.gameObject.GetComponent<PlayerLifeComponent>();      //se toma el Script PlayerLifeComponent de la colision (jugador)
            GameManager.Instance.Botiquin();                                                        //se llama al metodo del Game Manager que se encarga de subir la vida del jugador
            Destroy(gameObject);                                                                    //Se destruye el botiquín
        }
    }
}
