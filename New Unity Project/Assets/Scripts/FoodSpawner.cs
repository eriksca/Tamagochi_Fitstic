using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> foodPrefabs;
    [SerializeField] int maxPrefabs;
    [SerializeField] int coroutineRepeatRate;
    bool stopInstantiate;
    [SerializeField] float foodHeight;
    [SerializeField] float delayOnStart;

    int prefabCounter = 0;

    private Vector3 planeDimensions;
   


    private void Start()
    {
        //StartCoroutine(SpawnFood());
        stopInstantiate = false;
        planeDimensions = GameObject.FindGameObjectWithTag("Ground").transform.localScale;
        Debug.Log(planeDimensions);
        LaunchSpawnCoroutine(delayOnStart);
    }

    private void Update()
    {
        if (prefabCounter == foodPrefabs.Count)
        {
            prefabCounter = 0;
        }
        if (stopInstantiate)
        {
            StopCoroutine(SpawnFood());
            Debug.LogWarning("Stop Coroutine");
            stopInstantiate = false;

        }
        
    }
    public IEnumerator SpawnFood()
    {
        Debug.Log("Start to instantiate food prefabs");
        
  
          for (int i = 0; i < maxPrefabs; i++)
          {
                Vector3 spawnPos = new Vector3(Random.Range(planeDimensions.x*10/2, -planeDimensions.x*10/2), foodHeight, Random.Range(planeDimensions.z*10/2, -planeDimensions.z*10 / 2));
            //Debug.LogError(spawnPos);
                GameObject prefabToPlace = Instantiate(foodPrefabs[prefabCounter], spawnPos, Quaternion.identity);


            
            if (prefabCounter < foodPrefabs.Count)
            {
                prefabCounter++;
                Debug.Log($"Food num: {prefabCounter}");

            }
            
            yield return new WaitForSeconds(coroutineRepeatRate);
            
          }
        stopInstantiate = true;
       

        


       
    }

    private void LaunchSpawnCoroutine(float time)
    {
        Invoke(nameof(StartSpawn), time);
    }
    private void StartSpawn()
    {
        StartCoroutine(SpawnFood());
    }

}
