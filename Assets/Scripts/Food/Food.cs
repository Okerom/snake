using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static event Action ServerOnFoodEaten;
    [SerializeField] GameObject particlePrefab;
    [Server]
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        //FindObjectOfType<Snake>().AddTail();
        //GameObject boom = Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);
        //NetworkServer.Spawn(boom);
        //StartCoroutine(delay_destroy(boom, 3f));
        OnServerParticles();
        NetworkServer.Destroy(gameObject);
        //FindObjectOfType<FoodSpawner>().Spawnfood();
        ServerOnFoodEaten?.Invoke();
    }

    [ServerCallback]
    void OnServerParticles()
    {
        GameObject boom = Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom);
        StartCoroutine(delay_destroy(boom, 3f));
    }

    IEnumerator delay_destroy(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        NetworkServer.Destroy(obj);
    }
}
