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
    private float direction;
    #endregion

    #region References
    private GameObject _player;
    private MovementComponent _movementComponent;
    #endregion

    #region Methods
    public float Damage() 
    { return _damage; }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _movementComponent = _player.GetComponent<MovementComponent>();
        direction = _movementComponent.getDirection();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1 * _speed * Time.deltaTime *direction,0));
    }
    
    #endregion
}