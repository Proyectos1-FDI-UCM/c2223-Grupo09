using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region References
    [SerializeField]
    private GameObject[] _totalVidas;   //son todos los corazones a rellenar. Inicialmente son 3, cuando se puedan obtener m�s con los engranajes aumentar� este n�mero
    private int _numTotalVidas;         //m�s tarde tambi�n se tendr� que leer mediante getter, por ahora son 3
    [SerializeField]
    private GameObject[] _hearts;       //los corazones que llevan el contador de vidas que tiene el jugador. Inicialmente son 3, cada vez que el jugador recibe da�o disminuye
    private int _numHearts;           
    #endregion
    #region Methods
    void MuestraVidas(GameObject[] _totalVidas)//muestra todos los corazones disponibles, ya sean "sano o da�ados"
     {
        for (int i = 0; i < _numTotalVidas; i++)
        {
            _totalVidas[i].SetActive(true);
        }
        for (int i = _numTotalVidas; i < _totalVidas.Length; i++)
        {
            _totalVidas[i].SetActive(false);
        }
    }
    void MuestraCorazones(GameObject[] _hearts)
    {
      /*  //muestra los corazones "sanos"
        for (int i = 0; i < _numHearts; i++)
        {
            _hearts[i].SetActive(true);
        }*/
        //muestra los corazones "da�ados"
        for(int i = _numHearts; i < _hearts.Length; i++)
        {
            _hearts[i].SetActive(false);
        }
    }
    #endregion
    void Start() 
    {
        _numTotalVidas = 3;//asi por ahora
        //MuestraVidas(_totalVidas);
       // MuestraCorazones(_hearts);
    }
    void Update()
    {
        //El n�mero de corazones sanos se obtiene del script PlayerLifeComponent. En el update porque se va actualizando cada vez que recibe da�o o recoge botiqu�n
        _numHearts = PlayerLifeComponent.Instance.Puntos_vida;
        MuestraVidas(_totalVidas);
        MuestraCorazones(_hearts);
    }
}
