using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComponent : MonoBehaviour
{
    #region References
    [SerializeField] private Transform Spikes;
    [SerializeField] private SpriteRenderer Background;
    #endregion
    #region Parameters
    public enum Boss_State {FullHealth, PrimeraFase, SegundaFase, Muerto}
    [SerializeField]
    private float _hp;
    private float _maxHp;
    public Animator _animator;
    private Boss_State _boss;
    private Boss_State _newBossState;
    public Boss_State BossState
    {
        get { return _boss; }
    }
    #endregion
    #region Methods
    public void IsAttacked(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _newBossState = Boss_State.Muerto;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _maxHp = _hp;
        _boss = Boss_State.FullHealth;
        _newBossState = Boss_State.FullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_boss != _newBossState)
        {
            if (_newBossState == Boss_State.PrimeraFase)
            {
                Spikes.Translate(new Vector2(0, 1));
                Background.color = new Color(0.45f, 0.07f, 0.07f, 1f);
                _boss = _newBossState;
            }
            else if (_newBossState == Boss_State.SegundaFase)
            {

            }
            else if (_newBossState == Boss_State.Muerto)
            {

            }
        }
        else
        {
            if(_boss == Boss_State.FullHealth)
            {
                if (_maxHp != _hp) _newBossState = Boss_State.PrimeraFase;
            }
        }
    }
}
