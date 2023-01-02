using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	public NavMeshAgent agent;
	public Transform player;
	public LayerMask whatIsGround, whatIsPlayer;
	// enemy properties
	public GameObject projectile;
	public float health;
	// states
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;
	// patrol
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;
	// attack
	public float timeBetweenAttacks;
	bool alreadyAttacked;
	private GameObject thePlayer;
	private void Awake() {
		player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
		thePlayer = GameObject.Find("Player");
    }

    private void Update() {
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer); 
		//Action States
		if (!playerInSightRange && !playerInAttackRange) Patrolling();
		if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		if (playerInSightRange && playerInAttackRange) AttackPlayer();
	}

	private void SearchWalkPoint() {
		float randomX = Random.Range(-walkPointRange, walkPointRange);
		float randomZ = Random.Range(-walkPointRange, walkPointRange);

		walkPoint = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);

		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
	}

	private void Patrolling() {
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet) agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
	}

	private void ChasePlayer() {
		agent.SetDestination(player.position);
	}

	private void ResetAttack() {
		alreadyAttacked = false;
	}

	private void AttackPlayer() {
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if (!alreadyAttacked) {
			// attack
			Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rb.AddForce(transform.up * 8f, ForceMode.Impulse);
			// reset attack
			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
	}
	// damage/death
	public void TakeDamage(int damage) {
		health -= damage;
		thePlayer.GetComponent<ScoreKeeper>().addScore(10);
		if (health <= 0)
			{
				thePlayer.GetComponent<ScoreKeeper>().addScore(100);
				Invoke(nameof(DestroyEnemy), 2f);
			}

        }

        private void DestroyEnemy() {
		Destroy(gameObject);
	}
	// misc
	// visualize attack and sight range
	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
}
