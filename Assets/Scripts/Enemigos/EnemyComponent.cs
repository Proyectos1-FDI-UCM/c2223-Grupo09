using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    #region references
    private WayPointsMovement _myWayPoints;
    private CapsuleCollider2D _myCapsuleCollider;
    private ShootComponent _myShootComponent;
    #endregion
    #region Parameters
    [SerializeField]
    private float _hp;
    [SerializeField]
    private AudioClip _soundExplosion;
    public bool Died;
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
            Died = true;
           if(_myWayPoints != null)
           {
              _myWayPoints.enabled = false;
           }
            _myCapsuleCollider.enabled = false;
            muerte = true;
            AudioControler.Instance.PlaySound(_soundExplosion);
            if (_animator != null)
            {
                _animator.SetBool("Muerte", muerte);
            }

            StartCoroutine(Wait());
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Dead();
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
        /*if (other.GetComponent<Escenario>() != null)
        {
            Debug.Log("entro");
            _myWayPoints.DontGoToPlayer();
        }*/
    }
    #endregion
    private void Start()
    {
        _myWayPoints = GetComponent<WayPointsMovement>();
        _myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        
    }
    public void BossDeath()
    {
        Died = true;
        _myWayPoints.enabled = false;
        _myCapsuleCollider.enabled = false;
        muerte = true;
        AudioControler.Instance.PlaySound(_soundExplosion);
        if (_animator != null) _animator.SetBool("Muerte", muerte);
        StartCoroutine(Wait());
    }
}

