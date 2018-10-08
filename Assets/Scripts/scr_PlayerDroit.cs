using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerDroit : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeedD;
    public bool attaqueD;
    public GameObject sabreAttaqueD;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(moveSpeedD, 0f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            body.velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-moveSpeedD, 0f);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            body.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            StartCoroutine(Attaque());
        }
    }

    public IEnumerator Attaque()
    {
        attaqueD = true;
        sabreAttaqueD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attaqueD = false;
        sabreAttaqueD.SetActive(false);
    }
}
