using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject player, mainPanel;

	// Update is called once per frame
	void Update () 
	{
		player.transform.Rotate(0.0f,20 * Time.deltaTime, 0.0f);
	}

	public void ChangeToScene (string scene)
	{
		SceneManager.LoadScene (scene);
		//Application.LoadLevel (scene);
	}

	public void ShowMainPanel(GameObject panel)
	{
		player.SetActive (true);
		mainPanel.SetActive (true);
		panel.SetActive (false);
	}

	public void ShowSecondaryPanel (GameObject panel)
	{
		player.SetActive (false);
		mainPanel.SetActive (false);
		panel.SetActive (true);
	}

	public void QuitGame() 
	{
		Application.Quit();	
	}
}
