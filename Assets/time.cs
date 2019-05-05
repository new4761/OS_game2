using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public Text t;
    public float num;


    void Update()
    {
        num -= Time.deltaTime;
        t.text = Mathf.Round(num).ToString();
        if (num <= 0) t.text = "END TIME";

    }
}
