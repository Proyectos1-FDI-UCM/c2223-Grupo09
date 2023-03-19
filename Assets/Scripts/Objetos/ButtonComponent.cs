using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    /*[SerializeField]
    private Transform _player;*/
    public GameObject platform;
    private WayPointsMovement _myWayPoints;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {  
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            platform.GetComponent<WayPointsMovement>().enabled = true;
        }
    }

    // Update is called once per frame
    void Start()
    {
        platform.GetComponent<WayPointsMovement>().enabled = false;
    }
}
