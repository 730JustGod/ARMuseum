using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openwindow : MonoBehaviour
{
    private bool windowState = false; //用一个bool值来表示窗户的状态,false表示关闭，true表示开启
    private Animation anim;
    public string animName = "openwindow"; //将动画片段的名称用一个共有变量来表示


    private float fingerActionSensitivity = Screen.width * 0.05f; //手指动作的敏感度，这里设定为 二十分之一的屏幕宽度.
                                                                  //
    private float fingerBeginX;
    private float fingerBeginY;
    private float fingerCurrentX;
    private float fingerCurrentY;
    private float fingerSegmentX;
    private float fingerSegmentY;
    private int fingerTouchState;
    
    private int FINGER_STATE_NULL = 0;
    private int FINGER_STATE_TOUCH = 1;
    private int FINGER_STATE_ADD = 2;

    private GameObject item;
    void Start()
    {
        // 找到动画组件引用
        anim = GetComponent<Animation>();

        fingerActionSensitivity = Screen.width * 0.02f;

        fingerBeginX = 0;
        fingerBeginY = 0;
        fingerCurrentX = 0;
        fingerCurrentY = 0;
        fingerSegmentX = 0;
        fingerSegmentY = 0;

        fingerTouchState = FINGER_STATE_NULL;
    }

    void Update()
    {
        item = GetComponent<change_items>().nowItem;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (fingerTouchState == FINGER_STATE_NULL)
            {
                 fingerTouchState = FINGER_STATE_TOUCH;
                 fingerBeginX = Input.mousePosition.x;
                 fingerBeginY = Input.mousePosition.y;
            }

        }
        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            fingerCurrentX = Input.mousePosition.x;
            fingerCurrentY = Input.mousePosition.y;
            fingerSegmentX = fingerCurrentX - fingerBeginX;
            fingerSegmentY = fingerCurrentY - fingerBeginY;
        }
        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            float fingerDistance = fingerSegmentX * fingerSegmentX + fingerSegmentY * fingerSegmentY;

            if (fingerDistance > (fingerActionSensitivity * fingerActionSensitivity))
            {
                if (fingerSegmentX > 0)
                {
                    Debug.Log("right");
                    //开窗操作
                    if (!windowState)
                    {
                        if (anim.isPlaying == false) //判断该动画是否正在播放
                        {
                            anim[animName].speed = 1;
                            anim.Play(animName); // 播放动画
                            windowState = !windowState; // bool值取反
                            item.GetComponent<display_item>().flag1 = true;
                        }
                    }
                }
                else
                {
                    Debug.Log("left");
                    //关窗操作
                    if (windowState)
                    {
                        if (anim.isPlaying == false) //判断该动画是否正在播放
                        {
                            // 设置开始播放的时间为最后的时刻，默认是从0s开始播放的
                            anim[animName].time = anim[animName].length;
                            anim[animName].speed = -1;
                            anim.Play(animName); // 播放动画
                            windowState = !windowState; // bool值取反
                            item.GetComponent<display_item>().flag2 = true;
                        }
                    }
                }


            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fingerTouchState = FINGER_STATE_NULL;
        }

    }

}