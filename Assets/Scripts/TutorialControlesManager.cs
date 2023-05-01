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
    [SerializeField] GameObject Controls_H;
    private bool H = false;
    int shift_pressed;
    // Start is called before the first frame update
    void Start()
    {
        Controls_W.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Arrows.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Shift.GetComponent<SpriteRenderer>().enabled = false;
        Controls_Space.GetComponent<SpriteRenderer>().enabled = false;
        Controls_H.GetComponent<SpriteRenderer>().enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
        {
            if (AD)
            {
                StartCoroutine(Delete_AD());
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (W)
            {
                StartCoroutine(Delete_W());
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Arrows && !W)
            {
                StartCoroutine(Delete_Arrows());
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (shift_pressed>100)
            {
                StartCoroutine(Delete_Shift());
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Space && !H)
            {
                StartCoroutine(Delete_Space());
            }
        }
        if (Input.GetKey(KeyCode.H))
        {
            if (H && !Shift)
            {
                StartCoroutine(Delete_H());
            }
        }
    }

    public void Message(int n)
    {
        if (n == 1)
        {
            Arrows = true;
            if(Controls_Arrows != null)Controls_Arrows.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (n == 2)
        {
            Shift = true;
            if (Controls_Shift != null) Controls_Shift.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (n == 3)
        {
            StartCoroutine(Delete_H());            
            Space = true;
            if (Controls_Space != null) Controls_Space.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (n == 4)
        {
            if (Shift)
            {
                StartCoroutine(Delete_Shift());
            }
            H = true;
            if (Controls_H != null) Controls_H.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    void FixedUpdate()
    {
        if (Shift && !Arrows)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                shift_pressed++;
            }
            else if(shift_pressed>0)shift_pressed--;
        }
    }
    IEnumerator Delete_AD()
    {
        yield return new WaitForSeconds(1f);
        if (Controls_AD != null) Destroy(Controls_AD);
        W = true;
        if (Controls_W != null) Controls_W.GetComponent<SpriteRenderer>().enabled = true;
    }
    IEnumerator Delete_W()
    {
        yield return new WaitForSeconds(1f);
        W = false;
        if (Controls_W != null) Destroy(Controls_W);
    }
    IEnumerator Delete_Arrows()
    {
        yield return new WaitForSeconds(0.8f);
        Arrows = false;
        if (Controls_Arrows != null) Destroy(Controls_Arrows);
    }
    IEnumerator Delete_Shift()
    {
        yield return new WaitForSeconds(1.2f);
        Shift = false;
        shift_pressed = 0;
        if (Controls_Shift != null) Destroy(Controls_Shift);
    }
    IEnumerator Delete_Space()
    {
        yield return new WaitForSeconds(1.6f);
        Space = false;
        if (Controls_Space != null) Destroy(Controls_Space);
    }
    IEnumerator Delete_H()
    {
        yield return new WaitForSeconds(1.6f);
        H = false;
        if (Controls_H != null) Destroy(Controls_H);
    }
}
