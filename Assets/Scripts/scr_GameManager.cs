using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_GameManager : MonoBehaviour
{
    public Text timerTxt;
    public float timer;
    public int tempsRound;

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

        }
	}
}
