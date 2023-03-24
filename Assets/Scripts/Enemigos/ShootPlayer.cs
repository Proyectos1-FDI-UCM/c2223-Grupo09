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
    private bool _isPlaying = false;
    

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
                if(gameObject.GetComponent<EnemyComponent>().Died != true) Instantiate(_bullet, _shootTransform.position, transform.rotation);
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
