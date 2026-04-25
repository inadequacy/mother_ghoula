using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour {
    public Transform target;
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        // Set the target destination
        agent.SetDestination(target.position);
    }
}
