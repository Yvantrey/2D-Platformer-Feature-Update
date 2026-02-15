using UnityEngine;

public class StartButton : MonoBehaviour {

	public GameObject gameBackground;

	void Start() {
		Time.timeScale = 0;
	}

	public void StartGame() {
		gameBackground.SetActive(true);
		gameObject.transform.parent.gameObject.SetActive(false);
		Time.timeScale = 1;
	}
}
