using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetElementController : MonoBehaviour {

    public float TTemp = 10f;
    public float transferHeat = 0.5f;

    static public float temp;

    private Text targetElementTemp;

    void Start ()
    {
        temp = TTemp;
        //targetElementTemp = transform.GetChild(0).GetComponent<Text>();
        //targetElementTemp.text = temp.ToString();
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            temp += transferHeat * Time.deltaTime;

    }

}
