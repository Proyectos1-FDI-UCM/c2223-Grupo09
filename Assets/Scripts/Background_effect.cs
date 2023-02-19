using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_effect : MonoBehaviour
{
    #region references
    [SerializeField] private GameObject cam;
    #endregion
    #region properties
    private float _lenght;
    private float _startPos;
    private float _dist;
    private float _temp;
    [SerializeField] private float _speed;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        _temp = cam.transform.position.x * (1 - _speed);
        _dist = cam.transform.position.x * _speed;
        transform.position = new Vector2(_startPos + _dist, transform.position.y);
        if (_temp > _startPos + _lenght) _startPos += _lenght;
        else if (_temp < _startPos - _lenght) _startPos -= _lenght;
    }
}
