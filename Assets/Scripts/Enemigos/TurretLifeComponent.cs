using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLifeComponent : MonoBehaviour
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
    //public Animator _animator;
    private bool muerte = false;
    #endregion

    #region Methods
    private void Update()
    {
        if (_hp <= 0)
        {
            _myCapsuleCollider.enabled = false;
            muerte = true;
            //AudioControler.Instance.PlaySound(_soundExplosion);
            //_animator.SetBool("Muerte", muerte);
            StartCoroutine(Wait());
            Dead(); //Esta línea se quitará cuando se tengan que meter animaciones y eso. Tan solo la he puesto para que la muerte sea instantánea
        }
    }
    private void Dead()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletComponent>() != null)
        {
            Destroy(other.gameObject);
            _hp--;
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
        //_animator = GetComponent<Animator>();
        _myCapsuleCollider = GetComponent<CapsuleCollider2D>();        
    }
}

