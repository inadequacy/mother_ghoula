using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class MoveToTarget : MonoBehaviour {
    public Transform target;
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
            StartCoroutine(NoiseHeard(target.position));
        if (currentDistanceToPlayer >= (playerDetectedRange + 2f))
            ResetAggro();
    }

    public IEnumerator NoiseHeard(Vector3 source)
    {
        scream.Play();
        yield return new WaitForSeconds(1);
        isChasing = true;
        agent.SetDestination(new Vector3(source.x, 0, source.y));
    }

    void ResetAggro()
    {
        isChasing = false;
    }
}
