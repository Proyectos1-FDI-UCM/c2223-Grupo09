using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public bool IsShooting;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _restingSpeed;
    private float _restingTime = 0.5f;
    [SerializeField]
    private Transform _shootTransform;
    [SerializeField]
    private Animator _myAnimator;
    [SerializeField]
    private AudioClip _shootSound;
    private bool _isPlaying = false;
    private EnemyComponent _enemyComponent;
   
    void Start()
    {
        IsShooting = false;
        _enemyComponent= GetComponent<EnemyComponent>();
    }

    void Update()
    {
        if (IsShooting)
        {
            _restingTime -= Time.deltaTime;

            if (_restingTime <= 0)
            {
                if(_enemyComponent == null) Instantiate(_bullet, _shootTransform.position, transform.rotation);
                else if (_enemyComponent.Died != true) Instantiate(_bullet, _shootTransform.position, transform.rotation);
                if (_myAnimator != null) _myAnimator.SetBool("_Shoot", true);
                if (_isPlaying == false)
                {
                    AudioControler.Instance.PlaySound(_shootSound);
                    _isPlaying = true;
                    StartCoroutine(Wait());
                    _isPlaying = false;
                }
                _restingTime = _restingSpeed;                
            }
        }        
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
