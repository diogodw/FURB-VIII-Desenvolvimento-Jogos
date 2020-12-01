using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    void Start()
    {
        if (Manager.Instance.started) 
            GameObject.Find("ResumeButton").GetComponent<Button>().interactable = true;
    }

}
