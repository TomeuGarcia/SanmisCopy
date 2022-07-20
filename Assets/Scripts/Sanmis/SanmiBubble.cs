using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmiBubble : MonoBehaviour
{
    [SerializeField] GameObject[] sanmiPrefabs;
    [SerializeField, Range(1, 10)] int minNumberOfSpawns = 1;
    [SerializeField, Range(1, 10)] int maxNumberOfSpawns = 1;
    [SerializeField, Range(0.0f, 5.0f)] float spawnAreaSize = 3.0f;

    [SerializeField] Collider collider;

    [SerializeField] GameObject particles;


    private void OnValidate()
    {
        if (maxNumberOfSpawns < minNumberOfSpawns)
        {
            maxNumberOfSpawns = minNumberOfSpawns;
        }
    }

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

        StartCoroutine(DieAnimation());
    }



    public void SpawnSanmis(SanmisController sanmisController)
    {
        int numberOfSpawns = Random.Range(minNumberOfSpawns, maxNumberOfSpawns);

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
        Vector3 offset = Random.insideUnitSphere * spawnAreaSize;
        offset.y = 0.0f;

        return transform.position + offset;
    }


    private void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DieAnimation()
    {
        collider.enabled = false;

        PlayParticles();
        yield return new WaitForSeconds(0.5f);

        Die();
    }


    private void PlayParticles()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
    }

}
