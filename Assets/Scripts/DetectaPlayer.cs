using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    //[field: SerializeField]
    /*public bool PlayerInArea { get; private set; }
    public Transform Player { get; private set; }*/
    private WayPointsMovement myWayPoints;

    public bool EnterArea;

    /*[SerializeField]
    private string detectionTag = "Player";*/

    private void Start()
    {
        myWayPoints = GetComponent<WayPointsMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player detected");
            EnterArea = true;

            myWayPoints.goToPlayer();

           /* PlayerInArea = true;            
            Player = collision.gameObject.transform;     */
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
