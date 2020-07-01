using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_control : MonoBehaviour
{
    public int click_num = 0;
    public bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        click_num = click_num + 1;
    }
    public void playAudio()
    {
        isPlay = true;
    }
    public void playIsOk()
    {
        isPlay = false;
    }
}
