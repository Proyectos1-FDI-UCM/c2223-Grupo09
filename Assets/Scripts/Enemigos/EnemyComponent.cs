using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    #region references
    private WayPointsMovement _myWayPoints;
    #endregion
    #region Parameters
    [SerializeField]
    private float _hp;
    //[SerializeField]
    //private GameObject _deadEffect;
    public Animator _animator;
    #endregion

    #region Methods
    public void IsAttacked(float damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            _animator.SetBool("Muerte", true);
            StartCoroutine(Wait());      
        }
    }
    private void Dead()
    {
        //Instantiate(_deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletComponent>() != null)
        {
            Destroy(other.gameObject);
            _myWayPoints.enabled = false;
            //Destroy(gameObject);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.2f);
        Dead();
    }
    #endregion
    private void Start()
    {
        _myWayPoints = GetComponent<WayPointsMovement>();
    }
}

