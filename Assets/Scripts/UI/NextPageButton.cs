using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject[] hiddens;
    private int PageNumber=0;
    void Awake()
    {
        pages[0].SetActive(true);
        hiddens[0].SetActive(false);
        hiddens[1].SetActive(false);
        hiddens[2].SetActive(false);
        hiddens[3].SetActive(false);
    }
 

    public void NextPage()
    {
       
        if (PageNumber<pages.Length-2)
        {
            pages[PageNumber].SetActive(false);
            PageNumber++;
            pages[PageNumber].SetActive(true);
        }
        else
        {
            pages[pages.Length-1].SetActive(false);
            hiddens[0].SetActive(true);
            hiddens[1].SetActive(true);
            hiddens[2].SetActive(true);
            hiddens[3].SetActive(true);
        }
            


            }
        }
    
