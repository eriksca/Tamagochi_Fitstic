using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> foodPrefabs;
    [SerializeField] int maxPrefabs;
    [SerializeField] int coroutineRepeatRate;
    bool stopInstantiate;

    int prefabCounter = 0;


    private void Start()
    {
        StartCoroutine(SpawnFood());
        stopInstantiate = false;
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
                Vector3 spawnPos = new Vector3(Random.Range(-450, 450), 1, Random.Range(-450, 450));
               
                GameObject prefabToPlace = Instantiate(foodPrefabs[prefabCounter], spawnPos, Quaternion.identity);
                
                
                Debug.LogWarning(prefabCounter);
            if (prefabCounter < foodPrefabs.Count)
            {
                prefabCounter++;

            }
            
            yield return new WaitForSeconds(coroutineRepeatRate);
            
          }
        stopInstantiate = true;
       

        


       
    }

}
