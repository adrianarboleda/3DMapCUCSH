using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    public GameObject selectedObject;
    public Color selected;
    public Color notSelected;

    void Start()
    {
        selectedObject = GameObject.Find("PlantaBaja");
        selected = new Color(254, 0, 0, 0.3f);
        notSelected = new Color(160, 160, 160, 0.2f);
        Debug.Log("roomControllerStart");
    }

    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 ) )
            {
                
                Debug.Log(selectedObject.name);
                Debug.Log(hit.transform.gameObject.name);
                if (selectedObject.name != hit.transform.gameObject.name) {
                    Debug.Log("Is not selected");
                    selectedObject.GetComponent<Renderer>().material.color = notSelected;

                    hit.transform.gameObject.GetComponent<Renderer>().material.color = selected;
                    selectedObject =  hit.transform.gameObject;
                }
            }
        }
    }
}
