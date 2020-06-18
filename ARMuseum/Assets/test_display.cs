using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test_display : MonoBehaviour
{
    public GameObject text;
    public GameObject button_control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = button_control.GetComponent<click_control>().click_num+"";
    }
}
