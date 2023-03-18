using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComponent : MonoBehaviour
{
    #region References
    [SerializeField] private Transform Spikes;              //Referencia a las sierras que suben cuando comienza la batalla
    [SerializeField] private SpriteRenderer Background;     //Referencia al fondo de pantalla
    #endregion
    #region Parameters
    public enum Boss_State {FullHealth, PrimeraFase, SegundaFase, Muerto}   //Los estados en los que puede estar el jefe
    [SerializeField]
    private float _hp;                  //Vida en todo momento del boss (se puede ajustar delde el editor de unity)
    private float _maxHp;               //Vida máxima del boss
    public Animator _animator;          //El animator del boss
    private Boss_State _boss;           //Variable que indica el estado en el que está el boss en todo momento
    private Boss_State _newBossState;   //Variable usada para cambiar el estado del boss
    public Boss_State BossState         //Variable pública que permite ver el estado del boss
    {
        get { return _boss; }
    }
    public float HpBoss         //Variable pública que permite ver la vida del boss
    {
        get { return _hp; }
    }
    #endregion
    #region Methods
    public void IsAttacked(float damage) //Cuando el boss es atacado
    {
        _hp -= damage;  //Se resta puntos de vida
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _maxHp = _hp;                               //El Hp máximo del boss será el hp que tenga al principio del todo
        _boss = Boss_State.FullHealth;              //El boss empieza en el estado de FullHealth
        _newBossState = Boss_State.FullHealth;      //Para evitar errores, se le da este estado también al _newBossState
    }

    // Update is called once per frame
    void Update()
    {
        if(_boss != _newBossState)  //Si hay discrepancia, entonces eso significa que hay que cambiar de estado
        {
            if (_newBossState == Boss_State.PrimeraFase)        //Esto es que el boss ha sido disparado por primera vez, empezando así la batalla final
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                StartCoroutine(StartBattle());  //Se empieza la corrutina "StartBattle", que cambia el fondo de color y hace subir las sierras
                
                //Aquí debería comenzar la música de boss final, y tal vez alguna animación
            }
            else if (_newBossState == Boss_State.SegundaFase)   //Esto es que la vida del boss ha llegado hasta la mitad, comenzando así su segunda fase
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                
                //Aquí debería haber alguna animación y algún sonido que indique que ha habido un cambio en el patrón
            }
            else if (_newBossState == Boss_State.Muerto)        //Esto es que la vida del boss ha llegado a 0, haciendo así que muera
            {
                _boss = _newBossState;          //Se cambia el estado del boss

                //Aquí debería detenerse la música, poner un sonido de explosión, meter una animación, y poner una corutina que, tras un tiempo, pasa a la pantalla de victoria
            }
        }
        else //Si no hay ninguna discrepancia
        {
            if(_boss == Boss_State.FullHealth)
            {
                if (_maxHp != _hp) _newBossState = Boss_State.PrimeraFase;      //Aquí se comprueba que el boss realmente tenga la vida al completo
                else
                {
                    //aquí tal vez tenga que haber una animación, o las variables para que ataque estén seteadas a false, o algo
                }
            }
            if (_boss == Boss_State.PrimeraFase)
            {
                if (_maxHp/2 >= _hp) _newBossState = Boss_State.SegundaFase;    //Aquí se comprueba que el boss no tenga su vida a menos de la mitad
                else
                {
                    //Bucle de ataques de la fase 1
                }
            }
            if (_boss == Boss_State.SegundaFase)
            {
                if (0 >= _hp) _newBossState = Boss_State.Muerto;                //Aquí se comprueba que el boss aún tenga puntos de vida
                else
                {
                    //Bucle de ataques de la fase 2
                }
            }
        }
    }
    IEnumerator StartBattle()
    {
        float r=0.282f;     //Estas variables son mates para que funcione bien lo de la transición de colores. No os preocupéis por ello
        float gb=0.282f;
        for (int i = 0; i < 20; i++)
        {

            Spikes.Translate(new Vector2(0, 0.05f));
            Background.color = new Color(r, gb, gb, 1f);
            r += 0.0085f;
            gb += -0.0105f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
