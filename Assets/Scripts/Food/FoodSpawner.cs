using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        Spawnfood();
        Food.ServerOnFoodEaten += Spawnfood;
    }

    [Server]
    public void Spawnfood()
    {
        Vector3 pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        GameObject food = Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
        NetworkServer.Spawn(food);
        food.GetComponent<Food>(); //инициализируем поведение пули
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= Spawnfood;
    }


    //public void SpawnFood()
    //{
    //    Vector3 pos = new Vector3(
    //        Random.Range(-xSize, xSize),
    //        foodPrefab.transform.position.y,
    //        Random.Range(-zSize, zSize));
    //    Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
    //}
}
