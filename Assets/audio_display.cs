using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class audio_display : MonoBehaviour
{
    public GameObject text;
    public GameObject button_click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button_click.GetComponent<click_control>().isPlay)
        {
            text.GetComponent<Text>().text = "true";
        }
        else
        {
            text.GetComponent<Text>().text = "false";
        }
        
    }
}
