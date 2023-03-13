using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region References
    [Header("Corazones")]
    [SerializeField]
    private GameObject[] _totalVidas;   //son todos los corazones a rellenar. Inicialmente son 3, cuando se puedan obtener m�s con los engranajes aumentar� este n�mero
    private int _numTotalVidas;         //m�s tarde tambi�n se tendr� que leer mediante getter, por ahora son 3
    [SerializeField]
    private GameObject[] _hearts;       //los corazones que llevan el contador de vidas que tiene el jugador. Inicialmente son 3, cada vez que el jugador recibe da�o disminuye
    private int _numHearts;

    [Header("Enemigos")]
    public TextMeshProUGUI enemigoText;
    public TextMeshProUGUI contEnemigoText;
    private int _numEnemigos;
    private int _contEnemigos;
    #endregion
    #region Methods
    void MuestraVidas(GameObject[] _totalVidas) //muestra todos los corazones disponibles, ya sean "sano o da�ados"
    {
        if (_numTotalVidas > -1)
        {
            for (int i = 0; i < _numTotalVidas; i++)
            {
                _totalVidas[i].SetActive(true);
            }
        }
        if (_numTotalVidas > -1)
        {
            for (int i = _numTotalVidas; i < _totalVidas.Length; i++)
            {
                _totalVidas[i].SetActive(false);
            }
        }
    }
    void MuestraCorazones(GameObject[] _hearts)
    {
        //muestra los corazones "sanos"
        if (_numHearts > -1)
        {
            for (int i = 0; i < _numHearts; i++)
            {
                _hearts[i].SetActive(true);
            }
        }
        //muestra los corazones "da�ados"
        if (_numHearts > -1)
        {
            for (int i = _numHearts; i < _hearts.Length; i++)
            {
                _hearts[i].SetActive(false);
            }
        }
    }
    #endregion
    void Start() 
    {
        _numHearts = PlayerLifeComponent.Instance.Puntos_vida;         //El n�mero de corazones sanos se obtiene del script PlayerLifeComponent.
        _numTotalVidas = PlayerLifeComponent.Instance.Puntos_vida_max; //El n�mero maximo de corazones se obtiene del script PlayerLifeComponent.
        _numEnemigos = ControladorDeSalas.Instance.NumEnemigos;        //El n�mero de enemigos en cada sala
    }
    void Update()
    {
        _numHearts = PlayerLifeComponent.Instance.Puntos_vida;         // En el update porque se va actualizando cada vez que recibe da�o o recoge botiqu�n
        _numTotalVidas = PlayerLifeComponent.Instance.Puntos_vida_max; //En el update porque se va actualizando si el jugador compra corazones
        _numEnemigos = ControladorDeSalas.Instance.NumEnemigos;        // En el update porque cuando cambia de sala, cambia el numero de enemigos
        MuestraVidas(_totalVidas);
        MuestraCorazones(_hearts);
        enemigoText.text = _numEnemigos.ToString();
    }
}
