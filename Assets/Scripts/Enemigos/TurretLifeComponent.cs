using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLifeComponent : MonoBehaviour
{
    #region references
    private WayPointsMovement _myWayPoints;
    private CapsuleCollider2D _myCapsuleCollider;
    private BossComponent _bossComponent;
    private int pos;
    private ShootPlayer _myShootPlayer;
    #endregion
    #region Parameters
    [SerializeField]
    private bool _bossTurret;
    [SerializeField]
    private float _hp;
    [SerializeField]
    private AudioClip _soundExplosion;
    [SerializeField]
    private Animator _animator;
    #endregion

    #region Methods
    private void Update()
    {
        if (_hp <= 0)
        {
            AudioControler.Instance.PlaySound(_soundExplosion);
            if (_animator != null) _animator.SetBool("_Death", true);
            if (_myShootPlayer != null)_myShootPlayer.enabled = false;
            StartCoroutine(Wait());
            _myCapsuleCollider.enabled = false;

            // Dead(); //Esta línea se quitará cuando se tengan que meter animaciones y eso. Tan solo la he puesto para que la muerte sea instantánea
        }
    }
    private void Dead()
    {
        if (_bossTurret) _bossComponent.TurretDestroyed(pos);
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
        yield return new WaitForSeconds(0.5f);
        Dead();
    }
    #endregion
    private void Start()
    {
        _myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        if(_bossTurret)_bossComponent = GameObject.Find("Final Boss").GetComponent<BossComponent>();
        if (gameObject.transform.position.x > 16f && gameObject.transform.position.x < 17f) pos = 0;
        else if (gameObject.transform.position.x > 17f) pos = 1;
        else if (gameObject.transform.position.x > -6f && gameObject.transform.position.x < -4f) pos = 2;
        else if (gameObject.transform.position.x > -2f && gameObject.transform.position.x < 1f) pos = 3;
        _myShootPlayer = GetComponent<ShootPlayer>();
        if (_bossTurret) StartCoroutine(Entrada());
    }
    IEnumerator Entrada()
    {
        for(int i=0; i<80; i++)
        {
            gameObject.transform.Translate(new Vector2(0, -0.05f));
            yield return new WaitForSeconds(0.025f);
        }
    }
    public void BossDeath()
    {
        _hp = 0;
    }
}

