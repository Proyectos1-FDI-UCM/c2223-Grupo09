using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BossComponent;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    #region references
    private BossComponent BossComponent;
    private TurretLifeComponent _myTurretLife;
    private EnemyComponent _myEnemyComponent;
    #endregion
    void Start()
    {
        BossComponent = GameObject.Find("Final Boss").GetComponent<BossComponent>();
        _myEnemyComponent = gameObject.GetComponent<EnemyComponent>();
        if(_myEnemyComponent == null) _myTurretLife = gameObject.GetComponent<TurretLifeComponent>();
    }
    void Update()
    {
        if(BossComponent.BossState == BossComponent.Boss_State.Muerto)
        {
            if (_myEnemyComponent != null) _myEnemyComponent.BossDeath();
            else if (_myTurretLife != null) _myTurretLife.BossDeath();
            else Destroy(gameObject); 
        }
    }
}
