using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMController : MonoBehaviour
{
    public AudioClip music;
    private AudioSource back;
    public Slider slider;
    public Toggle muteToggle;//toggle组件  
    void Start()
        {
            back = this.GetComponent<AudioSource>();
            back.loop = true; //设置循环播放  
            back.volume = 0.5f;//设置音量最大，区间在0-1之间
            back.clip = music;
            back.Play(); //播放背景音乐
            muteToggle.isOn =false;
    }
    void Update()
    {
        back.volume = slider.value;
    }
    public void muteMusic()
    {
        if (muteToggle.isOn == true)//若勾选则静音
        {
            back.Pause();//声音暂停
        }
        else if (muteToggle.isOn == false)//若取消勾选取消静音
        {
            back.Play();//继续播放
        }
    }


}
