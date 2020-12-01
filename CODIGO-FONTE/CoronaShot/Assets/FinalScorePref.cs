using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScorePref : MonoBehaviour
{

    void Update()
    {
        GetComponent<Text>().text = Manager.Instance.score.ToString("0000");        
    }

}
