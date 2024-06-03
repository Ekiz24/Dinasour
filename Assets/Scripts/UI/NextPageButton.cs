using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject[] hiddens;
    private int PageNumber;
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
        if (PageNumber==pages.Length-1)
        {
            hiddens[0].SetActive(true);
            hiddens[1].SetActive(true);
            hiddens[2].SetActive(true);
            hiddens[3].SetActive(true);
        }

                pages[PageNumber].SetActive(false);

        if (PageNumber<pages.Length-1)
        {
            PageNumber++;
            pages[PageNumber].SetActive(true);
        }
            


            }
        }
    
