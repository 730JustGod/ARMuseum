using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_items : MonoBehaviour
{
    public GameObject allitem;
    public GameObject[] items;
    public GameObject button_control;
    public GameObject nowItem;
    int N;
    int num;
    int oldnum;
    // Start is called before the first frame update
    void Start()
    {

        button_control=GameObject.Find("Button_click_manager").gameObject;
        oldnum = 0;
        num = 0;
        N = allitem.transform.childCount;
        items = new GameObject[N];
        for(int i=0;i< allitem.transform.childCount; i++)
        {
            items[i] = allitem.transform.GetChild(i).gameObject;
        }
        nowItem = items[num % N];
    }

    // Update is called once per frame
    void Update()
    {
        if (button_control.GetComponent<click_control>().BoxRotate)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            button_control.GetComponent<click_control>().BoxRotate = false;
        }

        num = button_control.GetComponent<click_control>().click_num;
        if (oldnum != num)
        {
            items[oldnum % N].SetActive(false);
            items[num % N].SetActive(true);
            nowItem = items[num % N];
            oldnum = num;
        }
        if (button_control.GetComponent<click_control>().isPlay)
        {
            items[num % N].GetComponent<AudioSource>().Play(0);
            GameObject.Find("Button_click_manager").gameObject.GetComponent<click_control>().isPlay = false;
            GameObject.Find("Button_click_manager").gameObject.GetComponent<click_control>().playIsOk();
        }
    }
    
}
