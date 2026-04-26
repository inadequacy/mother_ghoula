using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class MoveToTarget : MonoBehaviour {
    public Transform target;
    public Player_Character player;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float playerDetectedRange = 50f;
    private float currentDistanceToPlayer;
    private NavMeshAgent agent;
    private AudioSource scream;
    private bool isChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        scream = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentDistanceToPlayer = Vector3.Distance(this.transform.position, target.transform.position);

        if (!agent.hasPath)
            agent.SetDestination(target.position);

        if (currentDistanceToPlayer <= playerDetectedRange)
            agent.speed = runSpeed;
        else
            agent.speed = walkSpeed;

        //// Set the target destination
        //if (!isChasing)
        //    agent.speed = walkSpeed;
        //else if (isChasing)
        //    agent.speed = runSpeed;

        ////if (!agent.hasPath)
        ////    agent.SetDestination(target.position);

        //if (currentDistanceToPlayer <= playerDetectedRange && isChasing == false)
        //    NoiseHeard(target.position);
        //else if (currentDistanceToPlayer <= playerDetectedRange && isChasing == true)
        //    agent.SetDestination(target.position);
        //else
        //{
        //    agent.SetDestination(target.position);
        //    ResetAggro();
        //}
        //Debug.Log(agent.stoppingDistance);
        //if (currentDistanceToPlayer <= 4.0f)
        //    player.GameOver();
    }

    public void NoiseHeard(Vector3 source)
    {
        if (!isChasing)
        {
            scream.Play();
            isChasing = true;
        }
        agent.SetDestination(source);
    }

    void ResetAggro()
    {
        isChasing = false;
    }
}
