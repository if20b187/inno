using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject Player;
    public GameObject Light;
    public GameObject Light2;
    //public GameObject Bird;
    //public GameObject BirdSpawnPoint;



    public GameObject CaveSpawn;
    public GameObject SpotLight;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Player.transform.position = spawnPoint.transform.position;
            //Bird.transform.position = BirdSpawnPoint.transform.position;


            if (spawnPoint.transform.position == CaveSpawn.transform.position)
            {
                Light.SetActive(false);
                Light2.SetActive(false);
                SpotLight.SetActive(true);
            }
            else
            {
                SpotLight.SetActive(false);
                Light.SetActive(true);
                Light2.SetActive(true);
            }
            
        }
    }
}
