using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

	public TextMeshProUGUI timerText;
	public GameObject endGamePanel;
	private float timeRemaining = 120f;
	private bool gameEnded = false;

	void Update() {
		if (timeRemaining > 0) {
			timeRemaining -= Time.deltaTime;
			int minutes = Mathf.FloorToInt(timeRemaining / 60);
			int seconds = Mathf.FloorToInt(timeRemaining % 60);
			timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		} else if (!gameEnded) {
			gameEnded = true;
			timeRemaining = 0;
			timerText.text = "00:00";
			endGamePanel.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
