using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmiBubble : MonoBehaviour
{
    [SerializeField] GameObject[] sanmiPrefabs;
    [SerializeField, Range(1, 10)] int numberOfSpawns = 1;
    [SerializeField, Range(0.0f, 5.0f)] float spawnSize = 3.0f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnSanmis(other.GetComponentInParent<SanmisController>());
        }
        else if (other.CompareTag("Sanmi"))
        {
            SpawnSanmis(other.GetComponentInParent<SanmisController>());
        }
    }



    public void SpawnSanmis(SanmisController sanmisController)
    {
        for (int i = 0; i < numberOfSpawns; ++i)
        {
            sanmisController.AddNewSanmi(GetNodeSpawnedSanmi(sanmiPrefabs[Random.Range(0, sanmiPrefabs.Length)], sanmisController.GetSanmisSpawnTransform()));
        }
    }


    private Sanmi GetNodeSpawnedSanmi(GameObject sanmiPrefab, Transform parent)
    {
        return Instantiate(sanmiPrefab, GetSpawnPosition(), transform.rotation, parent).GetComponent<Sanmi>();
    }


    private Vector3 GetSpawnPosition()
    {
        Vector3 offset = Random.insideUnitSphere * spawnSize;
        offset.y = 0.0f;

        return transform.position + offset;
    }


}
