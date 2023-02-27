using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    struct Vidas//En el juego tendremos un x max de vidas, por ej 6, pero estas 6 no apareceran en la interfaz desde el principio. El jugador empieza con 3 vidas desde el principio y luego podra obtener mas hasta ese maximo.
    {
        public GameObject [] vidas;
        public int num;
    }
    void Start() 
    {
        CreaArray(out Vidas hearts, 6);

    }
    void Update()
    {
        
    }
    static void CreaArray(out Vidas array, int n)//El array de corazones tendra tamaño maximo de corazones(max 6) y al principio seran visibles los 3 corazones iniciales
    {
       
        array.num = PlayerLifeComponent.Instance.Puntos_vida;
        array.vidas = new GameObject[n];
    }
}
