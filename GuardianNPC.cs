using UnityEngine;
using UnityEngine.AI;

// slap this on the NPC, it needs a NavMeshAgent or it'll yell at you
[RequireComponent(typeof(NavMeshAgent))]
public class GuardianNPC : MonoBehaviour
{
    [Header("Who am I following?")]
    public Transform playerTransform; // drag the player here in the inspector
    public float followDistance = 4.0f; // how close is too close?

    [Header("Timer Stuff")]
    private float timeRemaining = 180.0f; // 3 mins, don't ask me why 3 sounds good
    private bool isActive = true;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        // making sure he doesnt die to environmental bastards
        EnsureInvincibility();
    }

    void Update()
    {
        // if time's up, he just stands there. lazy. u can change it to do anything else = like it vanish into water lol
        if (!isActive) return;

        HandleCountdown();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // only move if we're outside the hug zone
        if (distance > followDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            // stop so we don't phase into the player's soul
            agent.isStopped = true;
        }
    }

    private void HandleCountdown()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            RetireNPC();
        }
    }

    private void RetireNPC()
    {
        isActive = false;
        agent.isStopped = true;
        Debug.Log("3 mins are up. i'm done.");
        
        // if u want him to puff into smoke or walk away, do it here. 
        // i'm just making him stop for now so it will just stay still 
    }

    private void EnsureInvincibility()
    {
        // change the tag so your enemies ignore him
        gameObject.tag = "Untagged"; 

        // if u have a 'God' layer, put him on it here
        // gameObject.layer = 2; // usually ignore raycast

        Debug.Log("he's invincible now, stop trying to kill him");
    }

    // if your combat script calls 'TakeDamage', this keeps it from breaking
    public void TakeDamage(float amount)
    {
        // haha nice try.
        Debug.Log("tried to kill him? lol no.");
    }
}
