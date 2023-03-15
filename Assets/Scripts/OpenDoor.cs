using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region references

    private ControladorDeSalas controladorDeSalas;
    private int contEnemigos = 1;
    private int alturaTope = 7;
    public float speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        /*if(contEnemigos == controladorDeSalas.NumEnemigos)
        {
           transform.Translate(Vector3.up * speed * Time.deltaTime);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (contEnemigos == controladorDeSalas.NumEnemigos)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
