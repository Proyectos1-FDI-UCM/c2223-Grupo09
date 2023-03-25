using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    [SerializeField]
    private AudioClip _botiquinSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)                       //si el botiquín entra en contacto con el jugador
        {
            AudioControler.Instance.PlaySound(_botiquinSound);
            GameManager.Instance.Botiquin();
            Destroy(gameObject);                                                                    //Se destruye el botiquín
        }
    }
}
