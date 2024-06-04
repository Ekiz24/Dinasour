using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] tools;
    public GameObject winPanel;
    public GameObject failPanel;

    public int playerHP // 添加一个公开的属性来获取当前血量
    {
        get { return playerHealth; }
    }

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private float speed = 10.9f;
    private int toolNumber;
    private int playerHealth = 3;
    private int kills = 0;

    private void Awake()
    {
      
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        tools[0].SetActive(true);
        

    }

    // Update is called once per frame
    private void Update()
    {
        #region Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //When player press left or right
        if (horizontal != 0)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", 0);
        }
        //When player press up or down
        if (vertical != 0)
        {
            animator.SetFloat("Vertical", vertical);
            animator.SetFloat("Horizontal", 0);
        }
        //the player changes stand to move
        Vector2 direction = new Vector2(horizontal, vertical);
        animator.SetFloat("Speed", direction.magnitude);

        //move character to the direction
        rigidbody2d.velocity = direction * speed;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -32f, 32f), Mathf.Clamp(transform.localPosition.y, -32f, 32f), 0f);
        #endregion

        #region Switch Tool
        SwitchTool();
        #endregion
        if (kills >= 6)
        {
            gameObject.SetActive(false);
            winPanel.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dinosaur"))
        {
            playerHealth--;
            kills++;
            Debug.Log("PlayerHealth:" + playerHealth);
            Debug.Log("PlayerKills:" + kills);
            Destroy(collision.gameObject);
            if(playerHealth<=0)
            {
                Debug.Log("You failed!");
                gameObject.SetActive(false);
                failPanel.SetActive(true);
            }

        }
    }


    private void SwitchTool()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            bool ice = DataSaveManager.Instance.GetIceActivation();
            bool berry = DataSaveManager.Instance.GetBerryActivation();
            if (ice ==true && berry==true)
            {
                tools[toolNumber].SetActive(false); //the current tool is not active
                if (++toolNumber > tools.Length - 1)
                {
                    toolNumber = 0; //if the Tool Number exceeds the number of total, then let it be 0 again
                }
                tools[toolNumber].SetActive(true); //the new tool is active now
            }
            else if(ice == true && berry==false)
            {
                tools[toolNumber].SetActive(false); //the current tool is not active
                if (++toolNumber > tools.Length - 2)
                {
                    toolNumber = 0; //if the Tool Number exceeds the number of total, then let it be 0 again
                }
                tools[toolNumber].SetActive(true); //the new tool is active now
            }
            else if(ice ==false && berry==true)
                {
                if (toolNumber == 0)
                {
                    toolNumber = toolNumber + 2;
                    tools[0].SetActive(false);
                    tools[2].SetActive(true);
                }
                if (toolNumber == 2)
                {
                    toolNumber = toolNumber - 2;
                    tools[2].SetActive(false);
                    tools[0].SetActive(true);
                }

            }
            else
            {
                Debug.Log("Not Enough Tools!");
            }
        }
    }

    public void AddKills()
    {
        kills++;
        Debug.Log("You captured"+kills);

    }
}
