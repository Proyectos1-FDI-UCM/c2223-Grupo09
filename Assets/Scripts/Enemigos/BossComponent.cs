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
    private float _maxHp;               //Vida m�xima del boss
    public Animator _animator;          //El animator del boss
    private Boss_State _boss;           //Variable que indica el estado en el que est� el boss en todo momento
    private Boss_State _newBossState;   //Variable usada para cambiar el estado del boss
    public Boss_State BossState         //Variable p�blica que permite ver el estado del boss
    {
        get { return _boss; }
    }
    public float HpBoss         //Variable p�blica que permite ver la vida del boss
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
        _maxHp = _hp;                               //El Hp m�ximo del boss ser� el hp que tenga al principio del todo
        _boss = Boss_State.FullHealth;              //El boss empieza en el estado de FullHealth
        _newBossState = Boss_State.FullHealth;      //Para evitar errores, se le da este estado tambi�n al _newBossState
    }

    // Update is called once per frame
    void Update()
    {
        if(_boss != _newBossState)  //Si hay discrepancia, entonces eso significa que hay que cambiar de estado
        {
            if (_newBossState == Boss_State.PrimeraFase)        //Esto es que el boss ha sido disparado por primera vez, empezando as� la batalla final
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                StartCoroutine(StartBattle());  //Se empieza la corrutina "StartBattle", que cambia el fondo de color y hace subir las sierras
                
                //Aqu� deber�a comenzar la m�sica de boss final, y tal vez alguna animaci�n
            }
            else if (_newBossState == Boss_State.SegundaFase)   //Esto es que la vida del boss ha llegado hasta la mitad, comenzando as� su segunda fase
            {
                _boss = _newBossState;          //Se cambia el estado del boss
                
                //Aqu� deber�a haber alguna animaci�n y alg�n sonido que indique que ha habido un cambio en el patr�n
            }
            else if (_newBossState == Boss_State.Muerto)        //Esto es que la vida del boss ha llegado a 0, haciendo as� que muera
            {
                _boss = _newBossState;          //Se cambia el estado del boss

                //Aqu� deber�a detenerse la m�sica, poner un sonido de explosi�n, meter una animaci�n, y poner una corutina que, tras un tiempo, pasa a la pantalla de victoria
            }
        }
        else //Si no hay ninguna discrepancia
        {
            if(_boss == Boss_State.FullHealth)
            {
                if (_maxHp != _hp) _newBossState = Boss_State.PrimeraFase;      //Aqu� se comprueba que el boss realmente tenga la vida al completo
                else
                {
                    //aqu� tal vez tenga que haber una animaci�n, o las variables para que ataque est�n seteadas a false, o algo
                }
            }
            if (_boss == Boss_State.PrimeraFase)
            {
                if (_maxHp/2 >= _hp) _newBossState = Boss_State.SegundaFase;    //Aqu� se comprueba que el boss no tenga su vida a menos de la mitad
                else
                {
                    //Bucle de ataques de la fase 1
                }
            }
            if (_boss == Boss_State.SegundaFase)
            {
                if (0 >= _hp) _newBossState = Boss_State.Muerto;                //Aqu� se comprueba que el boss a�n tenga puntos de vida
                else
                {
                    //Bucle de ataques de la fase 2
                }
            }
        }
    }
    IEnumerator StartBattle()
    {
        float r=0.282f;     //Estas variables son mates para que funcione bien lo de la transici�n de colores. No os preocup�is por ello
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
