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

    #region References
    private MovementComponent _movementComponent;
    #endregion

    #region Methods
    public float Damage() 
    { return _damage; }

    private void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime *_movementComponent.getDirection());
    }
    
    #endregion
}