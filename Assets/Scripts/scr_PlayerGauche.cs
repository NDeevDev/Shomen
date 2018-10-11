using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_PlayerGauche : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeedG;
    public bool attaqueG;
    public GameObject sabreAttaqueG;

    public Text scoreDTxt;
    public int scoreD;

    public GameObject joueurG;
    public GameObject joueurD;

    private bool canMove = true;
    private bool canAttack = true;
    private bool canDash = true;

    public float dashKeyHold;

    void Start ()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                body.velocity = new Vector2(moveSpeedG, 0f);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                body.velocity = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                body.velocity = new Vector2(-moveSpeedG, 0f);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                body.velocity = Vector2.zero;
            }
            if (Input.GetKeyDown(KeyCode.C) && canAttack)
            {
                StartCoroutine(Attaque());
            }
        }
        if (canMove == false)
        {
            body.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            canMove = false;
            dashKeyHold += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    public IEnumerator Attaque()
    {
        attaqueG = true;
        sabreAttaqueG.SetActive(true);
        canAttack = false;
        yield return new WaitForSeconds(0.2f);
        attaqueG = false;
        sabreAttaqueG.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
    }

    private IEnumerator Dash()
    {
        canDash = false;

        body.AddForce(Vector2.right * dashKeyHold, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(0.1f);
        canMove = true;
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SabreD")
        {
            StartCoroutine(EndRoundG());
        }
    }

    public IEnumerator EndRoundG()
    {
        canMove = false;
        scoreD++;
        scoreDTxt.text = scoreD.ToString();
        yield return new WaitForSecondsRealtime(2f);
        joueurG.transform.position = new Vector2(-3f, 0f);
        joueurD.transform.position = new Vector2(3f, 0f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<scr_GameManager>().timer = 0f;
        canMove = true;
    }
}
