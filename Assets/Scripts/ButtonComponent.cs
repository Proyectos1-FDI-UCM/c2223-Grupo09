using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private WayPointsMovement _myWayPoints;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.transform.position.y > transform.position.y)
        {
            _myWayPoints.enabled = true;
        }
    }

    // Update is called once per frame
    void Start()
    {
        _myWayPoints.enabled = false;
    }
}
