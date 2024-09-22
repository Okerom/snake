using UnityEngine;
using System.Collections;
public class script : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Положение точки назначения
    public int rast;
    public bool s = true;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 30)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) > rast)
            {
                UnityEngine.AI.NavMeshAgent agent
                = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = player.transform.position;
            }
            else
            {
                UnityEngine.AI.NavMeshAgent agent
                = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = gameObject.transform.position;
                if (s == true)
                {
                    StartCoroutine(hhh());
                }
            }
        }
    }

    IEnumerator hhh()
    {
        s = false;
        yield return new WaitForSeconds(10);
        if (rast >= 1) 
        {
            rast -= 1;
            s = true;
        }
    }
}