using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movLatEnemigos : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    private Vector2 siguientePosicion;

    private float distanciaCambio = 0.5f;

    private int numeroSigPosicion = 0;

    [SerializeField]
    private float velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidad * Time.deltaTime);

        if(Vector2.Distance(transform.position,siguientePosicion) < distanciaCambio) 
        {
            numeroSigPosicion++;

            if (numeroSigPosicion <= waypoints.Length)
            {
                numeroSigPosicion = 0;
                siguientePosicion = waypoints[numeroSigPosicion].position;
            }

        }
    }
}
