using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    public List<GameObject> Tails { get; } = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += AddTail;
        
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= AddTail;
    }

    void AddTail()
    {   
        var tailInstance = Instantiate
            (tailPrefab,
            Tails.Count == 0 ?
            transform.position :
            Tails[Tails.Count - 1].transform.position,
            Quaternion.identity);
        NetworkServer.Spawn(tailInstance);
        Tails.Add(tailInstance);
    }
}
