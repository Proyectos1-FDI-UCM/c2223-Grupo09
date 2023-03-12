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
    public Animator _animator;
    #endregion

    #region
    private BulletComponent bulletComponent;
    #endregion

    #region Methods
    // Update is called once per frame
    private void Start()
    {
        bulletComponent = GetComponent<BulletComponent>();
    }
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
        _animator.SetBool("Muerto", true);
        //Instantiate(_deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BulletComponent>() != null)
        {
            IsAttacked(bulletComponent.getDamage());
            Destroy(gameObject);
        }
    }
    #endregion
}
