using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_rotate : MonoBehaviour
{
    public float speed = 60f;
    public GameObject button_controller;
    public GameObject text;
    private Vector3 OldRotation;
    // Start is called before the first frame update
    void Start()
    {
        button_controller = GameObject.Find("Button_click_manager").gameObject;
        OldRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (button_controller.GetComponent<click_control>().isRotate)
        {
            this.transform.Rotate(new Vector3(0, 0, 1 * Time.deltaTime * speed));
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }

    }
}
