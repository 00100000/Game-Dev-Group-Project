using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject playerBody;

	public GameObject winScreen;
	public GameObject lossScreen;

	bool thirdPerson = false;

	void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (thirdPerson) {
				mainCamera.transform.position = playerBody.transform.position + playerBody.transform.TransformDirection(new Vector3(0, 0.95f, 0));
				thirdPerson = false;
			} else {
				mainCamera.transform.position = playerBody.transform.position + playerBody.transform.TransformDirection(new Vector3(0, 5f, -5f));
				thirdPerson = true;
			}
		}
	}

	public void EndWin() {
		winScreen.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
	}

	public void EndLoss() {
		lossScreen.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
	}

	public void RestartButton() {
		SceneManager.LoadScene("Game");
	}
}
