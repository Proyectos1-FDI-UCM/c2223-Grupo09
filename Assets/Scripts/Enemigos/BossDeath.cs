using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BossComponent;

public class BossDeath : MonoBehaviour
{
    private BossComponent BossComponent;
    private TurretLifeComponent _myTurretLife;
    private EnemyComponent _myEnemyComponent;
    // Start is called before the first frame update
    void Start()
    {
        BossComponent = GameObject.Find("Final Boss").GetComponent<BossComponent>();
        _myEnemyComponent = gameObject.GetComponent<EnemyComponent>();
        if(_myEnemyComponent == null) _myTurretLife = gameObject.GetComponent<TurretLifeComponent>();
    }

    // Update is called once per frame
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
