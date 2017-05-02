using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetElementController : MonoBehaviour {

    public float TTemp = 10f;
    public float transferHeat = 0.5f;
    public Scrollbar targetEBar;
    public Text targetEText;

    static public float temp;

    private Text targetElementTemp;
    private float maxTemp = 100f;

    void Awake()
    {
        temp = TTemp;
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
            temp += transferHeat * Time.deltaTime;
            SetTempBar();
            SetTempText();
        }
    }

    void SetTempBar()
    {
        targetEBar.size = temp / maxTemp;
    }

    void SetTempText()
    {
        targetEText.text = temp.ToString("N0");
    }
}
