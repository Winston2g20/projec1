using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float timerfloat = 0f;
    TMPro.TextMeshProUGUI tmp;
    GameObject textobj;
    string textstring;
    void Start()
    {
        textobj = this.gameObject;
        tmp = textobj.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        timerfloat = timerfloat + 0.02f;
        // Debug.Log("timerfloat " + timerfloat.ToString());
        TimeSpan ts = TimeSpan.FromSeconds(timerfloat);
        textstring = ts.ToString("m\\:ss\\.ff");
        tmp.text = textstring;
    }
}
