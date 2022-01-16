using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> foodPrefabs;
    [SerializeField] int maxPrefabs;
    //GameManager gManager;
    int prefabCounter = 0;


    private void Start()
    {
        StartCoroutine(SpawnFood());
    }
    public IEnumerator SpawnFood()
    {
        Debug.Log("CIAO");

        
            Debug.Log("Porcodddio");
            for (int i = 0; i < maxPrefabs; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-450, 450), 1, Random.Range(-450, 450));
                if (prefabCounter < foodPrefabs.Count)
                {
                    prefabCounter++;

                }
                else if(prefabCounter==foodPrefabs.Count-1)
                {
                    prefabCounter = 0;
                Debug.LogError("Dio santo");
                }
                GameObject prefabToPlace = Instantiate(foodPrefabs[prefabCounter], spawnPos, Quaternion.identity);
                
                
                Debug.LogWarning(prefabCounter);
                yield return new WaitForSeconds(2f);
            }

        


       
    }

}
