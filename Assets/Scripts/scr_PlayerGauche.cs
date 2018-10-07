using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerGauche : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed;
    public bool attaque;
    public GameObject sabreAttaque;

	void Start ()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
		if (Input.GetAxis("Horizontal") != 0)
        {
            body.velocity = new Vector2 (Input.GetAxis("Horizontal") * moveSpeed,0f);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            body.velocity = Vector2.zero;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attaque());
        }
	}

    public IEnumerator Attaque()
    {
        attaque = true;
        sabreAttaque.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attaque = false;
        sabreAttaque.SetActive(false);
    }
}
