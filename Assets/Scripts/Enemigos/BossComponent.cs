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
                _boss = _newBossState;
                StartCoroutine(StartBattle());                
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
            if (_boss == Boss_State.PrimeraFase)
            {
                if (_maxHp/2 >= _hp) _newBossState = Boss_State.SegundaFase;
            }
        }
    }
    IEnumerator StartBattle()
    {
        float r=0.282f;
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
