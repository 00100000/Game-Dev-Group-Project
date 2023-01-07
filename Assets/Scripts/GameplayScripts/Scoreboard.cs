using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour {
	public TextMeshProUGUI text;
	GameObject[] list;
	// damage/death
	public void Update() {
		list = GameObject.FindGameObjectsWithTag("Enemy");
		text.SetText("Llamas Left: " + list.Length.ToString());
		if (list.Length == 0) {
			FindObjectOfType<Manager>().EndWin();
		}
	}
}
