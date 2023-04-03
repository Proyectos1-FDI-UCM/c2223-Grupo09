using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutBossComponent : MonoBehaviour
{
    #region properties
    private static TutBossComponent _instance;
    public static TutBossComponent Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion
    public enum Tut_Boss_State { Wait, PrimeraFase, SegundaFase, Muerto }   //Los estados en los que puede estar el jefe
    #region References
    [Header("Referencias del Boss")]
    [SerializeField]
    private GameObject[] Torretas;
    [SerializeField] private GameObject[] Proyectiles;
    [SerializeField] private Animator _myAnimator;
    [SerializeField] private Transform _puerta;
    #endregion

    #region Parameters
    [Header("Atributos del Boss")]
    [SerializeField]
    private float _hp;                  //Vida en todo momento del boss (se puede ajustar delde el editor de unity)
    private float _maxHp;               //Vida máxima del boss
    private bool Attack;
    private bool Rayo;
    private Tut_Boss_State _boss;           //Variable que indica el estado en el que está el boss en todo momento
    private Tut_Boss_State _newBossState;   //Variable usada para cambiar el estado del boss
    public Tut_Boss_State BossState         //Variable pública que permite ver el estado del boss
    {
        get { return _boss; }
    }
    public float HpBoss         //Variable pública que permite ver la vida del boss
    {
        get { return _hp; }
    }
    public float HPMax         //Variable pública que permite ver la vida del boss
    {
        get { return _maxHp; }
    }
    private bool Started=false;
    #endregion

    #region Methods
    public void IsAttacked(float damage) //Cuando el boss es atacado
    {
        if(_boss == Tut_Boss_State.SegundaFase ) _hp -= damage;  //Se resta puntos de vida
    }
    private void Muerte()
    {
        if (0 >= _hp)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        //FinalScene();
    }
    #endregion
    private void Awake()
    {
        if (_instance != null && _instance != this) //Instanciar, hacer Singlenton este script
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _maxHp = _hp;                               //El Hp máximo del boss será el hp que tenga al principio del todo
        _boss = Tut_Boss_State.Wait;              //El boss empieza en el estado de FullHealth
        _newBossState = Tut_Boss_State.Wait;      //Para evitar errores, se le da este estado también al _newBossState
        Attack = false;
        Rayo = false;
    }

    // Update is called once per frame
    void Update()
    {
        Muerte();
        if (_boss != _newBossState)  //Si hay discrepancia, entonces eso significa que hay que cambiar de estado
        {
            if (_newBossState == Tut_Boss_State.PrimeraFase)        //Esto es que el boss ha sido disparado por primera vez, empezando así la batalla final
            {
                _boss = _newBossState;                          //Se cambia el estado del boss
                Torretas[0].GetComponent<TutBossEnabler>().Enable();
                Torretas[1].GetComponent<TutBossEnabler>().Enable();    
                gameObject.GetComponent<WayPointsMovement>().enabled = true;
                //Aquí debería comenzar la música de boss final, y tal vez alguna animación
            }
            else if (_newBossState == Tut_Boss_State.SegundaFase)   //Esto es que la vida del boss ha llegado hasta la mitad, comenzando así su segunda fase
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                Rayo = true;
                Attack = true;                                  //Le permite al boss atacar
                StartCoroutine(GetDown());

                //Aquí debería haber alguna animación y algún sonido que indique que ha habido un cambio en el patrón
            }
            else if (_newBossState == Tut_Boss_State.Muerto)        //Esto es que la vida del boss ha llegado a 0, haciendo así que muera
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                StartCoroutine(Muero());

                //Aquí debería detenerse la música, poner un sonido de explosión, meter una animación, y poner una corutina que, tras un tiempo, pasa a la pantalla de victoria
            }
        }
        else //Si no hay ninguna discrepancia
        {
            if (_boss == Tut_Boss_State.PrimeraFase)
            {
                if (Torretas[0]==null && Torretas[1]==null) _newBossState = Tut_Boss_State.SegundaFase;    //Aquí se comprueba que el boss no tenga su vida a menos de la mitad
            }
            if (_boss == Tut_Boss_State.SegundaFase)
            {
                if (0 >= _hp) _newBossState = Tut_Boss_State.Muerto;                //Aquí se comprueba que el boss aún tenga puntos de vida
                else
                {
                    if (Attack) StartCoroutine(Shoot());
                    if (Rayo) StartCoroutine(AttackDown(Random.Range(4f, 6f)));
                }
            }
        }
    }
    public void Empiezo()
    {
        if (!Started)
        {
            _newBossState = Tut_Boss_State.PrimeraFase;
            Started = true;
        }            
    }
    IEnumerator Muero()
    {
        _myAnimator.SetBool("_Death", true);
        yield return new WaitForSeconds(1f);
        _puerta.Translate(new Vector2(0, 5f));
        Destroy(gameObject);
    }
    IEnumerator GetDown()
    {
        gameObject.GetComponent<WayPointsMovement>().UnlockX();
        for (int i = 0; i < 20; i++)
        {
            transform.Translate(new Vector2(0, -0.15f));
            yield return new WaitForSeconds(0.025f);
        }
    }
    IEnumerator AttackDown(float time)
    {
        Rayo = false;        
        yield return new WaitForSeconds(time);        
        if (_boss != Tut_Boss_State.Muerto)
        {
            for (int i = 0; i < 50; i++)
            {
                transform.Translate(new Vector2(0, -0.15f));
                yield return new WaitForSeconds(0.020f);
            }
            for (int i = 0; i < 50; i++)
            {
                transform.Translate(new Vector2(0, 0.15f));
                yield return new WaitForSeconds(0.015f);
            }
            Rayo = true;
        }        
    }
    IEnumerator Shoot()
    {
        Attack = false;
        yield return new WaitForSeconds(1f);
        if (_boss != Tut_Boss_State.Muerto)
        {
            Instantiate(Proyectiles[0], transform.position, transform.rotation);
            Instantiate(Proyectiles[1], transform.position, transform.rotation);
            Instantiate(Proyectiles[2], transform.position, transform.rotation);
            Attack = true;
        }
    }
}
