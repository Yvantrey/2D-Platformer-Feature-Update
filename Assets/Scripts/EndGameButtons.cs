using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtons : MonoBehaviour {

	public GameObject startPoint;
	public GameObject gameStart;

	public void Replay() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit() {
		startPoint.SetActive(true);
		gameStart.SetActive(false);
		gameObject.SetActive(false);
	}
}
