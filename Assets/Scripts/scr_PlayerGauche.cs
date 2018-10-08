using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerGauche : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeedG;
    public bool attaqueG;
    public GameObject sabreAttaqueG;

	void Start ()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
		if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2 (moveSpeedG,0f);
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Attaque());
        }
	}

    public IEnumerator Attaque()
    {
        attaqueG = true;
        sabreAttaqueG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attaqueG = false;
        sabreAttaqueG.SetActive(false);
    }
}
