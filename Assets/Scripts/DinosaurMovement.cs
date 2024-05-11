using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class DinosaurMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 3f;

    private Seeker seeker;
    private List<Vector3> pathPointList;
    private int currentIndex = 0;// path point index
    private float pathGenerateInterval = 0.5f; //generate a path every 5 sec
    private float pathGenerateTimer = 0f;//timer for counting
    // Start is called before the first frame update
    void Awake()
    {
        seeker = GetComponent<Seeker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance < chaseDistance) //be in chase range
        {
            AutoPath();

            if (pathPointList == null)
                return;

                //chase player
                //The enemy's starting to move in the direction of the path point.
                Vector2 direction = (pathPointList[currentIndex] - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * moveSpeed, Space.World);
        }
        else
        {
            //OnMovementInput?.Invoke(Vector2.zero);
        }
    }


    private void AutoPath()
    {
        pathGenerateTimer += Time.deltaTime;
        //GeneratePath function called every 0.5 seconds
        if (pathGenerateTimer >= pathGenerateInterval)
        {
            GeneratePath(player.position);
            pathGenerateTimer = 0;
        }


        if (pathPointList == null || pathPointList.Count <= 0)
        {
            GeneratePath(player.position);
            //Get the path points, then pass the player's position
        }
        //Calculate the distance between the enemy's position and the current path point
        else if (Vector2.Distance(transform.position, pathPointList[currentIndex]) <= 0.1f)
        {
            //If the distance is already less than 0.1, the enemy has reached the player's location
            currentIndex++;
            //then increment the value of currentIndex to point the index to the next path point
            if (currentIndex >= pathPointList.Count)
                //Indicates that the end of the path point has been reached
                GeneratePath(player.position);
            //Recapture the path points between the enemy and the player
        }
    }

    //get path point before starting auto-pathfinding
    private void GeneratePath(Vector3 target)
    {
        currentIndex = 0;

        /*3 parameters: start point, end point, callback function
         * callback function: Called only when the current calculation is complete
         * Lambda expression: an expression for an anonymous function that can be used to define simple one-off functions.
         * Path is the parameter, 
         * => followed by the result of the path computed by the Path parameter accepted by the expression or statement block
         * 
         * Assigns a value to pathPointList. 
         * When the player's position is passed as an argument, 
         * we can get all the path points from the enemy to the player and store them in the pathPointList.
        */
        seeker.StartPath(transform.position, target, Path => 
        {
            pathPointList = Path.vectorPath;
        });
    }
}
