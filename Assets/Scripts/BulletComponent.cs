using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    #endregion

    #region Methods
    public float Damage() 
    { return _damage; }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    
    #endregion
}
