using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField]
    private AudioClip _buttonSound;
    [SerializeField]
    private GameObject[] platforms;
    private WayPointsMovement _myWayPoints;
    public Sprite flatButton;
    private BoxCollider2D _myBoxCollider;
    private bool _pressed;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {  
        if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            for(int i=0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<WayPointsMovement>().enabled = true;
            }
            
            GetComponent<Animator>().enabled = true;
            Flatten();
            if (!_pressed)
            {
                AudioControler.Instance.PlaySound(_buttonSound);
                _pressed = true;
            }               
        }
    }

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].GetComponent<WayPointsMovement>().enabled = false;
        }
        GetComponent<Animator>().enabled = false;
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _pressed = false;
    }

    private void Flatten()
    {        
        GetComponent<SpriteRenderer>().sprite = flatButton;
        GetComponent<Animator>().enabled = false;
        _myBoxCollider.size = new Vector2(_myBoxCollider.size.x, 0.12f);        
    }
}
