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

        // Set the target destination
        if (!agent.hasPath)
            agent.SetDestination(target.position);
        if (!isChasing)
            agent.speed = walkSpeed;
        else if (isChasing)
            agent.speed = runSpeed;

        if (currentDistanceToPlayer <= playerDetectedRange)
            NoiseHeard(target.position);
        if (currentDistanceToPlayer <= playerDetectedRange && isChasing)
            agent.SetDestination(target.position);
        if (currentDistanceToPlayer >= (playerDetectedRange + 2f))
            ResetAggro();
        if (currentDistanceToPlayer <= 5.0f)
            player.GameOver();
    }

    void NoiseHeard(Vector3 source)
    {
        scream.Play();
        isChasing = true;
        agent.SetDestination(new Vector3(source.x, 0, source.y));
    }

    void ResetAggro()
    {
        isChasing = false;
    }
}
