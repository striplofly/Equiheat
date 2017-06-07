using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetElementController : MonoBehaviour {

    public float initialTemp = 10f;
    public float transferHeat = 0.5f;
    public Scrollbar targetEBar;
    public Text targetEText;

    static public float currentTemp;

    private Text targetElementTemp;
    private float maxTemp = 100f;

    void Awake()
    {
		currentTemp = initialTemp;
    }

    void Start()
    {
        SetTempBar();
        SetTempText();

    }

		
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
			//Debug.Log ("Collision detected");
			currentTemp += transferHeat * Time.deltaTime;
            SetTempBar();
            SetTempText();
        }
    }

    void SetTempBar()
    {
		targetEBar.size = currentTemp / maxTemp;
    }

    void SetTempText()
    {
		targetEText.text = currentTemp.ToString("N0");
    }
}
