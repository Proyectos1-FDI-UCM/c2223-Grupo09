using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region references
    //ControladorDeSalas controladorDeSalas;
    public int numEnemigos;
    private float alturaTope = 7.0f;
    [SerializeField]
    private float speed = 3.0f;
    private Vector2 newPosition;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        numEnemigos = ControladorDeSalas.Instance.NumEnemigos;
        newPosition = new Vector2(transform.position.x, alturaTope);
    }

    // Update is called once per frame
    void Update()
    {
        numEnemigos = ControladorDeSalas.Instance.NumEnemigos;

        if (numEnemigos == 0)
        {
            AbrePuerta();
        }
    }

    public void AbrePuerta()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}
