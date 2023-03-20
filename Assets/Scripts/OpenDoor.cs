using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region references
    ControladorDeSalas controladorDeSalas;
    public int contEnemigos;
    public int numEnemigos;
    private int alturaTope = 7;
    public float speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        controladorDeSalas = GetComponent<ControladorDeSalas>();
        numEnemigos = ControladorDeSalas.Instance.NumEnemigos;
        contEnemigos = ControladorDeSalas.Instance.ContEnemigos; 
    }

    public void Kill()
    {
        contEnemigos++;
    }

    // Update is called once per frame
    void Update()
    {
        if (contEnemigos == numEnemigos)
        {
            AbrePuerta();
        }
    }

    public void AbrePuerta()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
