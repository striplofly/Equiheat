using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public Text playerTemp;
    public Text targetTemp;

    private bool isFinish;

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
        if (Mathf.Round(PlayerController.temp) == Mathf.Round(TargetElementController.temp))
        {
            TimerController.isCountdown = false;
            isFinish = true;
            winPanel.SetActive(true);
        }

        setTempature();

        yield return null;
    }

    void setTempature()
    {
        playerTemp.text = PlayerController.temp.ToString("N0");
        targetTemp.text = TargetElementController.temp.ToString("N0");
    }
}
