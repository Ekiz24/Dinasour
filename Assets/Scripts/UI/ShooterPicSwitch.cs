using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShooterPicSwitch : MonoBehaviour
{
    public GameObject[] toolsPic;
    private int toolsPicNumber;
    // Start is called before the first frame update
    void Awake()
    {
        toolsPic[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            toolsPic[toolsPicNumber].SetActive(false); //the current tool is not active
            if (++toolsPicNumber > toolsPic.Length - 1)
            {
                toolsPicNumber = 0; //if the Tool Number exceeds the number of total, then let it be 0 again
            }
            toolsPic[toolsPicNumber].SetActive(true); //the new tool is active now
        }
    }
}
