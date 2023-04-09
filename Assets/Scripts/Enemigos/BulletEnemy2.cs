using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy2 : MonoBehaviour
{
    private GameObject _player;
    private Vector2 _direction;
    private float _speed = 5.5f;
    [SerializeField] private bool _turretBullet;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_turretBullet && _player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }        
        _direction = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y);
        _direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction*Time.deltaTime*_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<KillPlayer>() == null&& collision.gameObject.GetComponent<DetectaPlayer>() == null)
        {
            Destroy(gameObject);
        }
    }
}
