using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_PlayerDroit : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeedD;
    public bool attaqueD;
    public GameObject sabreAttaqueD;

    public Text scoreGTxt;
    public int scoreG;

    public GameObject joueurG;
    public GameObject joueurD;

    private bool mort;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        moveSpeedD = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerGauche>().moveSpeedG;
    }

    void Update()
    {
        if (mort == false)
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
    }

    public IEnumerator Attaque()
    {
        attaqueD = true;
        sabreAttaqueD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attaqueD = false;
        sabreAttaqueD.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SabreG")
        {
            StartCoroutine(EndRoundD());
        }
    }

    public IEnumerator EndRoundD()
    {
        mort = true;
        scoreG++;
        scoreGTxt.text = scoreG.ToString();
        yield return new WaitForSecondsRealtime(2f);
        joueurG.transform.position = new Vector2(-3f, 0f);
        joueurD.transform.position = new Vector2(3f, 0f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<scr_GameManager>().timer = 0f;
        mort = false;
    }
}
