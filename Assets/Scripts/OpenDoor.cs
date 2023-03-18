using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region references

    private ControladorDeSalas controladorDeSalas;
    private int contEnemigos;
    private int numEnemigos;
    private int alturaTope = 7;
    public float speed;
    #endregion

    // Start is called before the first frame update
    /*void Start()
    {
        numEnemigos = ControladorDeSalas.Instance.NumEnemigos;
        contEnemigos = ControladorDeSalas.Instance.ContEnemigos;      
    }

    // Update is called once per frame
    void Update()
    {
        if (contEnemigos == numEnemigos)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }*/

    /*public void AbrePuerta()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }*/
}
