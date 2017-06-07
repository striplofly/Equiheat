using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera mainCam;
    public GameObject winPanel;
    public GameObject losePanel;
    public Text playerTemp;
    public Text targetTemp;

    public BoxCollider2D topWall, bottomWall, leftWall, rightWall;

    static public bool isFinish;


    void Start ()
    {
        //isFinish = false;

        SetupGameBoundary();
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

        if(Mathf.RoundToInt(PlayerController.temp) == 100)
        {
            isFinish = false;
            TimerController.isCountdown = false;
            FireController.isMoving = false;
            PlayerController.isMoving = false;
        }

        yield return null;
    }

    void SetupGameBoundary()
    {
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
    }

}
