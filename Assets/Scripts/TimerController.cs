using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public Text timer;
    public float timeLimit;
    static public bool isCountdown;

    void Start ()
    {
        isCountdown = true;
    }
	
	void Update ()
    {
        if (isCountdown)
            OnTimer();
    }

    void OnTimer()
    {
        if(timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            timer.text = "00:" + timeLimit.ToString("N0");

            if (timeLimit < 10 )
                timer.text = "00:0" + timeLimit.ToString("N0");
        }

        if (timeLimit < 0)
            isCountdown = false;
    }
}
