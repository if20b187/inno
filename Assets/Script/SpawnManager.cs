using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;

    public GameObject player;
    public GameObject car;
    public GameObject plane;
    public GameObject ball;
    public GameObject leiter;
    public GameObject box;

    public GameObject spawnLocation;
    public GameObject spawnLocationDirekt;

    // Update is called once per frame

    void Awake()
    {
        if (spawnManager == null)
        {
            spawnManager = this;
        }
        else if (spawnManager != this)
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);

    }
    
    public void HandleInput(string input)
    {
        switch (input)
        {
            case "spawnCar()":
                Instantiate(car, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), Quaternion.identity);
                break;
            case "spawnPlane()":
                Instantiate(plane, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), Quaternion.identity);
                break;
            case "spawnBall()":
                Instantiate(ball, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), Quaternion.identity);
                break;
            case "spawnLeiter()":
                Instantiate(leiter, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), Quaternion.identity);
                break;
            case "spawnBox()":
                Instantiate(box, new Vector3(spawnLocationDirekt.transform.position.x, spawnLocationDirekt.transform.position.y, spawnLocationDirekt.transform.position.z), Quaternion.identity);
                break;
            case "runFaster()":
                player.GetComponent<vThirdPersonController>().SetSprintSpeed(12f);
                break;
            case "runNormal()":
                player.GetComponent<vThirdPersonController>().SetSprintSpeed(6f);
                break;
            case "jumpNormal()":
                player.GetComponent<vThirdPersonController>().SetJumpHeight(4f);
                break;
            case "jumpHigher()":
                player.GetComponent<vThirdPersonController>().SetJumpHeight(8f);
                break;
            case "JumpSpeedFaster()":
                player.GetComponent<vThirdPersonController>().SetAirSpeed(10f);
                break;
            case "JumpSpeedNormal()":
                player.GetComponent<vThirdPersonController>().SetAirSpeed(5f);
                break;
            default:
                Debug.Log("False Input!");
                break;

        }

        /*
        if (input.Equals("spawnObj()"))
        {
            Instantiate(myPrefab, new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z), Quaternion.identity);
        }
        else
        {
            Debug.Log("False Input!");
        }
        */
    }
}
