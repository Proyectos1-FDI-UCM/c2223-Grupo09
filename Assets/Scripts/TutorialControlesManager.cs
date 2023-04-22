using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControlesManager : MonoBehaviour
{
    [SerializeField] GameObject Controls_AD;
    private bool AD = true;
    [SerializeField] GameObject Controls_W;
    private bool W = false;
    [SerializeField] GameObject Controls_Arrows;
    private bool Arrows = false;
    [SerializeField] GameObject Controls_Shift;
    private bool Shift = false;
    [SerializeField] GameObject Controls_Space;
    private bool Space = false;
    // Start is called before the first frame update
    void Start()
    {
        Controls_W.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Arrows.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Shift.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Space.GetComponent<SpriteRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
        {
            if (AD)
            {
                AD = false;
                StartCoroutine(Delete_AD());
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (W)
            {
                W = false;
                StartCoroutine(Delete_W());
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Arrows && !W)
            {
                Arrows = false;
                StartCoroutine(Delete_Arrows());
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Shift && !Arrows)
            {
                Shift = false;
                StartCoroutine(Delete_Shift());
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Shift && !Arrows)
            {
                Shift = false;
                StartCoroutine(Delete_Shift());
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Space)
            {
                Space = false;
                StartCoroutine(Delete_Space());
            }
        }
    }

    public void Message(int n)
    {
        if (n == 1)
        {
            Arrows = true;
            Controls_Arrows.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (n == 2)
        {
            Shift = true;
            Controls_Shift.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (n == 3)
        {
            if (Shift)
            {
                Shift = false;
                Delete_Shift();
            }
            Space = true;
            Controls_Space.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    IEnumerator Delete_AD()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(Controls_AD);
        W = true;
        Controls_W.GetComponent<SpriteRenderer>().enabled = true;
    }
    IEnumerator Delete_W()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(Controls_W);
    }
    IEnumerator Delete_Arrows()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(Controls_Arrows);
    }
    IEnumerator Delete_Shift()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(Controls_Shift);
    }
    IEnumerator Delete_Space()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(Controls_Space);
    }
}
