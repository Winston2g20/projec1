using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float timerfloat = 0f;
    TMPro.TextMeshProUGUI tmp;
    GameObject textobj;
    void Start()
    {
        textobj = this.gameObject;
        tmp = textobj.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = timerfloat.ToString();
    }
}
