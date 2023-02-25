using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerInArea { get; private set; }
    public Transform Player { get; private set; }
    
    WayPointsMovement myWayPoints;

    public bool EnterArea;

    [SerializeField]
    private string detectionTag = "Player";

    private void Start()
    {
        myWayPoints = GameObject.FindGameObjectWithTag("Enemy").GetComponent<WayPointsMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            Debug.Log("player detected");
            EnterArea = true; 
            PlayerInArea = true; 
            
            Player = collision.gameObject.transform;

            myWayPoints.goToPlayer();
   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnterArea = false;
            /* PlayerInArea = false;
            Player = null;*/
        }
    }

}
