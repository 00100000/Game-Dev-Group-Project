using UnityEngine;

public class Target : MonoBehaviour {
	public Transform player;
	public float health;
	// damage/death
	public void Update() {
		if (health <= 0) Invoke(nameof(DestroyEnemy), 2f);
	}

	public void TakeDamage(int damage) { health -= damage; }

	private void DestroyEnemy() {
		Destroy(gameObject);
	}
}
