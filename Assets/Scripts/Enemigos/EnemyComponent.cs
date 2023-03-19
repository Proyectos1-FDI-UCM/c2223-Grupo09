using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    #region references
    private WayPointsMovement _myWayPoints;
    private CapsuleCollider2D _myCapsuleCollider;
    #endregion
    #region Parameters
    [SerializeField]
    private float _hp;
    [SerializeField]
    private AudioClip _soundExplosion;
    //[SerializeField]
    //private GameObject _deadEffect;
    public Animator _animator;
    private bool muerte = false;
    #endregion

    #region Methods
    public void IsAttacked(float damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            _myCapsuleCollider.enabled = false;
            muerte = true;
            AudioControler.Instance.PlaySound(_soundExplosion);
            _animator.SetBool("Muerte", muerte);
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
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Dead();
    }
    #endregion
    private void Start()
    {
        _myWayPoints = GetComponent<WayPointsMovement>();
        _animator = GetComponent<Animator>();
       _myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        
    }
}

