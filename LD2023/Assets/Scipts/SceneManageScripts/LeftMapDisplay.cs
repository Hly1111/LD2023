using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftMapDisplay : MonoBehaviour
{
    public Image mapImage;
    public void Start(){
        mapImage = GetComponent<Image>();
        mapImage.enabled = false;
    }
    public void FixedUpdate(){
        if(Input.GetKey(KeyCode.Tab)){
            mapImage.enabled = true;
        }
        else{
            mapImage.enabled = false;
        }
    }
}
