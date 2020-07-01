using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_item : MonoBehaviour
{
    public bool flag1 = false;
    public bool flag2 = false;
    public string AnimName ;
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (flag1)
        {
            if (anim.isPlaying == false)
            {
                anim[AnimName].speed = 1;
                anim.Play(AnimName);
                flag1 = false;
            }
        }

        if (flag2)
        {
            if (anim.isPlaying == false)
            {
                anim[AnimName].time = anim[AnimName].length;
                anim[AnimName].speed = -1;
                anim.Play(AnimName);
                flag2 = false;
            }
        }
    }
}
