using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _hp;
    //[SerializeField]
    //private GameObject _deadEffect;
    #endregion

    #region Methods
    // Update is called once per frame
    public void IsAttacked(float damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        //Instantiate(_deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    #endregion
}
