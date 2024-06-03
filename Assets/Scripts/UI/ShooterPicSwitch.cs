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
            bool ice = DataSaveManager.Instance.GetIceActivation();
            bool berry = DataSaveManager.Instance.GetBerryActivation();
            if (ice == true && berry == true)
            {
                toolsPic[toolsPicNumber].SetActive(false); //the current tool is not active
                if (++toolsPicNumber > toolsPic.Length - 1)
                {
                    toolsPicNumber = 0; //if the Tool Number exceeds the number of total, then let it be 0 again
                }
                toolsPic[toolsPicNumber].SetActive(true); //the new tool is active now
            }
            else if (ice == true && berry == false)
            {
                toolsPic[toolsPicNumber].SetActive(false); //the current tool is not active
                if (++toolsPicNumber > toolsPic.Length - 2)
                {
                    toolsPicNumber = 0; //if the Tool Number exceeds the number of total, then let it be 0 again
                }
                toolsPic[toolsPicNumber].SetActive(true); //the new tool is active now
            }
            else if (ice == false && berry == true)
            {
                if (toolsPicNumber == 0)
                {
                    toolsPicNumber = toolsPicNumber + 2;
                    toolsPic[0].SetActive(false);
                    toolsPic[2].SetActive(true);
                }
                if (toolsPicNumber == 2)
                {
                    toolsPicNumber = toolsPicNumber - 2;
                    toolsPic[2].SetActive(false);
                    toolsPic[0].SetActive(true);
                }

            }
            else
            {
                Debug.Log("Not Enough Tools!");
            }
        }
    }
}
