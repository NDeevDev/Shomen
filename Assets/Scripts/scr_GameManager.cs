using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_GameManager : MonoBehaviour
{
    public Text timerTxt;
    public float timer;
    public int tempsRound;

    public GameObject joueurG;
    public GameObject joueurD;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (timer < tempsRound)
        {
            timer += Time.deltaTime;
            timerTxt.text = (tempsRound - Mathf.RoundToInt(timer)).ToString();
        }
        if (timer >= tempsRound)
        {
            joueurG.transform.position = new Vector2(-3f, 0f);
            joueurD.transform.position = new Vector2(3f, 0f);
            timer = 0f;
        }
        if (joueurG.transform.position.x > joueurD.transform.position.x)
        {
            joueurG.transform.localScale = new Vector3 (-1f, 1f, 1f);
            joueurD.transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        if (joueurG.transform.position.x < joueurD.transform.position.x)
        {
            joueurG.transform.localScale = new Vector3(1f, 1f, 1f);
            joueurD.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
