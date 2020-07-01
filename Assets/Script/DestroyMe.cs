using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public GameObject button_controller;
    public GameObject Plane_con;
    // Start is called before the first frame update
    void Start()
    {
        button_controller = GameObject.Find("Button_click_manager").gameObject;
        Plane_con = GameObject.Find("Plane_controller").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (button_controller.GetComponent<click_control>().die)
        {
            button_controller.GetComponent<click_control>().die = false;
            Destroy(gameObject);
        }
    }
}
