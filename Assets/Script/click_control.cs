using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_control : MonoBehaviour
{
    public int click_num = 0;
    public int rotate_num = 0;
    public bool isPlay = false;
    public bool isRotate = false;
    public bool BoxRotate = false;
    public bool die = false;
    public float speed = 5f;
    public GameObject Plane_con;
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
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void ToCardMode()
    {
        SceneManager.LoadScene(1);
    }
    public void ToNoCardMode()
    {
        SceneManager.LoadScene(2);
    }
    public void item_rotate()
    {
        if (rotate_num % 2 == 0)
        {
            isRotate = true;
        }
        else
        {
            isRotate = false;
        }
        rotate_num++;
    }
    public void fastRotate()
    {
        BoxRotate = true;
        
    }
    public void slowRotate()
    {
        BoxRotate = true;

    }
    public void refresh()
    {
        die = true;
        Plane_con.GetComponent<HelloARController>().hasFile = false;
    }
}
