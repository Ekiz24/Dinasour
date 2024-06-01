using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] HP;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerMovement.playerHP)
        {
            case 2:
                HP[2].SetActive(false);
                break;
            case 1:
                HP[1].SetActive(false);
                break;
            case 0:
                HP[0].SetActive(false);
                break;
        }


    }
}
