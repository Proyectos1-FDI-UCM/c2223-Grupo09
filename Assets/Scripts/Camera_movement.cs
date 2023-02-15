using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    #region references
    private Transform cam_Transform;                       //Transform de la cámara principal
    [SerializeField]private Transform player_Transform;    //Transform del jugador (Se selecciona en el menú de Unity) 
    #endregion
    #region constantes
    const float DIST_LATERAL = 2.5f;
    const float DIST_ALT_ABAJO = 3.5f;
    const float DIST_ALT_ARRIBA = 1.0f;
    #endregion
    void Start()
    {
        cam_Transform = transform;
    }
    void Update()
    {
        if (cam_Transform.position.x < (player_Transform.position.x - DIST_LATERAL))  //si la cámara esta mucho más a la izquierda que el jugador
        {
            cam_Transform.Translate(new Vector2((player_Transform.position.x - DIST_LATERAL) - cam_Transform.position.x, 0)); //Se mueve a la derecha lo mismo que el jugador
        }
        if (cam_Transform.position.x > (player_Transform.position.x + DIST_LATERAL))  //si la cámara esta mucho más a la derecha que el jugador
        {
            cam_Transform.Translate(new Vector2((player_Transform.position.x + DIST_LATERAL) - cam_Transform.position.x, 0)); //Se mueve a la izquierda lo mismo que el jugador
        }
        if (cam_Transform.position.y > (player_Transform.position.y + DIST_ALT_ABAJO))  //si la cámara esta mucho más arriba que el jugador
        {
            cam_Transform.Translate(new Vector2(0, (player_Transform.position.y + DIST_ALT_ABAJO) - cam_Transform.position.y)); //Se mueve hacia abajo lo mismo que el jugador
        }
        if (cam_Transform.position.y < (player_Transform.position.y - DIST_ALT_ARRIBA))  //si la cámara esta mucho más debajo que el jugador
        {
            cam_Transform.Translate(new Vector2(0, (player_Transform.position.y - DIST_ALT_ARRIBA) - cam_Transform.position.y)); //Se mueve hacia arriba lo mismo que el jugador
        }
    }
}
