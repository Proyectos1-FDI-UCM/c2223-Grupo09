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
    private float _restingTime = 2.0f;
    [SerializeField]
    private Transform _shootTransform;
    [SerializeField]
    private Animator _myAnimator;
    [SerializeField]
    private AudioClip _shootSound;

    void Start()
    {
        IsShooting = false;
    }

    void Update()
    {
        if (IsShooting)
        {
            _restingTime -= Time.deltaTime;

            if (_restingTime <= 0)
            {
                Instantiate(_bullet, _shootTransform.position, transform.rotation);
                _myAnimator.SetBool("_Shoot", true);
               // AudioControler.Instance.PlaySound(_shootSound);
                _restingTime = _restingSpeed;                
            }
        }        
    }
}
