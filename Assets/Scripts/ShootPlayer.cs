using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public bool IsShooting;
    [SerializeField]
    private GameObject _bullet;
    private float _restingTime = 2.0f;

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
                Instantiate(_bullet, transform.position, transform.rotation); 
                _restingTime = 2.0f;                
            }
        }        
    }
}
