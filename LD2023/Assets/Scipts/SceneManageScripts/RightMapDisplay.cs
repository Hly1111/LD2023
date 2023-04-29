using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMapDisplay : MonoBehaviour
{
    public Image mapImage;
    public void Start(){
        mapImage = GetComponent<Image>();
        mapImage.enabled = false;
    }
    public void FixedUpdate(){
        if(Input.GetKey(KeyCode.M)){
            mapImage.enabled = true;
        }
        else{
            mapImage.enabled = false;
        }
    }
}
