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
    public Sprite flatButton;
    private BoxCollider2D _myBoxCollider;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {  
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            platform.GetComponent<WayPointsMovement>().enabled = true;
            GetComponent<Animator>().enabled = true;
            Flatten();  
        }
    }

    // Update is called once per frame
    void Start()
    {
        platform.GetComponent<WayPointsMovement>().enabled = false;
        GetComponent<Animator>().enabled = false;
        _myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Flatten()
    {
        GetComponent<SpriteRenderer>().sprite = flatButton;
        GetComponent<Animator>().enabled = false;
        _myBoxCollider.size = new Vector2(_myBoxCollider.size.x, 0.12f);
    }
}
