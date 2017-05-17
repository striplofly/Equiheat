using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public Text playerTemp;
    public Text targetTemp;
	public bool isFinish;

    void Start ()
    {
        isFinish = false;
    }

    void Update ()
    {
        if (TimerController.isCountdown)
            StartCoroutine(CheckIfFinish());     

        if (!TimerController.isCountdown && !isFinish)
            losePanel.SetActive(true);   
    }

    IEnumerator CheckIfFinish()
    {
        if (Mathf.Round(PlayerController.currentTemp) == Mathf.Round(TargetElementController.currentTemp))
        {
            TimerController.isCountdown = false;
            isFinish = true;
            winPanel.SetActive(true);
        }

        yield return null;
    }
}
