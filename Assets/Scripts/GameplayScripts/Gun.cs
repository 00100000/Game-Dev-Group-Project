using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour {
	// properties
	public int damage;
	public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
	public int magazineSize, bulletsPerTap;
	public bool allowButtonHold;
	int bulletsLeft, bulletsShot;

	bool shooting, readyToShoot, reloading;
	// reference
	public Camera fpsCam;
	public Transform attackPoint;
	public RaycastHit rayHit;
	public LayerMask whatIsEnemy;
	// graphics
	public GameObject muzzleFlash, bulletHoleGraphic;
	// audio
	public AudioSource playerAudio;
	public AudioClip gunshot;
	// gui
	public TextMeshProUGUI text;
	// camera shake
	/*
	public CamShake camShake;
	public float camShakeMagnitude, camShakeDuration;
	*/

	private void Awake() {
		bulletsLeft = magazineSize;
		readyToShoot = true;
	}

	private void Update() {
		MyInput();
		// ammo info
		text.SetText(bulletsLeft + " / " + magazineSize);
	}

	private void MyInput() {
		if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
		else shooting = Input.GetKeyDown(KeyCode.Mouse0);

		if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

		if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
			bulletsShot = bulletsPerTap;
			Shoot();
		}
	}

	private void Shoot() {
		readyToShoot = false;
		// spread
		float x = Random.Range(-spread, spread);
		float y = Random.Range(-spread, spread);
		Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);
		// RayCast
		if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy)) {
			if (rayHit.collider.CompareTag("Enemy")) rayHit.collider.GetComponent<EnemyAI>().TakeDamage(damage);
		}
		playerAudio.PlayOneShot(gunshot, 1f);
		// camera shake
		/*
		camShake.Shake(camShakeDuration, camShakeMagnitude);
		*/
		// bullet holes
		Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.FromToRotation(Vector3.forward, rayHit.normal));
		Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

		bulletsLeft--;
		bulletsShot--;

		Invoke("ResetShot", timeBetweenShooting);
		if (bulletsShot > 0 && bulletsLeft > 0) Invoke("Shoot", timeBetweenShots);
	}

	private void Reload() {
		reloading = true;
		Invoke("ReloadFinished", reloadTime);
	}

	private void ReloadFinished() {
		bulletsLeft = magazineSize;
		reloading = false;
	}

	private void ResetShot() {
		readyToShoot = true;
	}
}
