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
    private GameObject[] _totalVidas;   //son todos los corazones a rellenar. Inicialmente son 3, cuando se puedan obtener más con los engranajes aumentará este número
    private int _numTotalVidas;         //más tarde también se tendrá que leer mediante getter, por ahora son 3
    [SerializeField]
    private GameObject[] _hearts;       //los corazones que llevan el contador de vidas que tiene el jugador. Inicialmente son 3, cada vez que el jugador recibe daño disminuye
    private int _numHearts;

    [Header("Enemigos")]
    [SerializeField]
    private TextMeshProUGUI _enemigoText;
    [SerializeField]
    private TextMeshProUGUI _contEnemigoText;
    private int _numEnemigos;
    private int _contEnemigos;

    [Header("Engranajes")]
    [SerializeField]
    private TextMeshProUGUI _gearText;
    private int _gearScore;

    #endregion
    #region Methods
    void MuestraVidas(GameObject[] _totalVidas) //muestra todos los corazones disponibles, ya sean "sano o dañados"
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
        //muestra los corazones "dañados"
        if (_numHearts > -1)
        {
            for (int i = _numHearts; i < _hearts.Length; i++)
            {
                _hearts[i].SetActive(false);
            }
        }
    }
     void GearScore()
     {
        _gearScore = GameManager.Instance.Gear;  //se toma el numero de engranajes del GameManager
        _gearText.text = _gearScore.ToString();

     }
    #endregion
    void Start() 
    {
        _numHearts = PlayerLifeComponent.Instance.Puntos_vida;         //El número de corazones sanos se obtiene del script PlayerLifeComponent.
        _numTotalVidas = PlayerLifeComponent.Instance.Puntos_vida_max; //El número maximo de corazones se obtiene del script PlayerLifeComponent.
        _numEnemigos = ControladorDeSalas.Instance.NumEnemigos;        //El número de enemigos en cada sala
    }
    void Update()
    {
        _numHearts = PlayerLifeComponent.Instance.Puntos_vida;         // En el update porque se va actualizando cada vez que recibe daño o recoge botiquín
        _numTotalVidas = PlayerLifeComponent.Instance.Puntos_vida_max; //En el update porque se va actualizando si el jugador compra corazones
        _numEnemigos = ControladorDeSalas.Instance.NumEnemigos;        // En el update porque cuando cambia de sala, cambia el numero de enemigos
        MuestraVidas(_totalVidas);
        MuestraCorazones(_hearts);
        GearScore();
        _enemigoText.text = _numEnemigos.ToString();
    }
}
