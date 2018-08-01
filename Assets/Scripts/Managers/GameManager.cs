using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject controlPanel;
	public Text levelText;
	public Text timerText; 
	public Text argolasText;
    public Text errosText;
	public Text healthText;
	public bool y_axis = false;
	public Interface interfc;

    public RawImage imagemAcerto;
    public RawImage imagemErro;

    [HideInInspector] public bool playersTurn = true;
	[HideInInspector] public bool spawnRings = true;
	[HideInInspector] public bool gameOver = false;
	[HideInInspector] public int argolas = 0;
    [HideInInspector] public int erros = 0;
	[HideInInspector] public int playerHealth = 1000;
	[HideInInspector] public static int level = 1;

	public float minutes = 3;
	private float seconds = 59;
	private float startMinutes;

	// Awake is always called before any Start functions
	void Awake ()
	{
		playersTurn = false;
		startMinutes = minutes;

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    

		// Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		if (Interface.instance.yToggle) {
            Destroy (GameObject.Find ("LeftWall"));
			Destroy (GameObject.Find ("RightWall"));
            //Debug.Log("Vertical was chosen");
		} else {
            Destroy (GameObject.Find ("TopWall"));
			Destroy (GameObject.Find ("BottomWall"));
            //Debug.Log("Horizontal was chosen");
        }
		interfc = GameObject.Find ("Preferencias").GetComponent<Interface> ();
		minutes = interfc.tempo;
		minutes--;

        //imagens só aparecem ao entrarem em contato com a argola
        imagemAcerto.enabled = false;
        imagemErro.enabled = false;
		InitGame();
	}

	void InitGame ()
	{
        levelText.text = "Nível: " + level;
        StartCoroutine("CountDown");
        
    }

	void Update ()
	{
		if (playersTurn) {
			controlPanel.SetActive (true);

			if(playerHealth == 0)
				GameOver();
			
			if (seconds <= 0) {
				seconds = 59;
				if (minutes >= 1) {
					minutes--;
				} else {
					minutes = 0;
					seconds = 0;
					//timerText.text = minutes.ToString("f0") + ":0" + seconds.ToString("f0");
					PlayerWins ();
				}
			} else {
				seconds -= Time.deltaTime;
			}

			if (!gameOver) {
				SetArgolasText ();
                SetErrosText();
                healthText.text = "Energia: " + playerHealth.ToString ();
				if (Mathf.Round (seconds) <= 9)
					timerText.text = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
				else 
					timerText.text = minutes.ToString ("f0") + ":" + seconds.ToString ("f0");
			}
		}
       
    }

	void GameOver()
	{
		playersTurn = false;
		spawnRings = false;
		gameOver = true;
		timerText.text = "";
		levelText.text = "Fim de Jogo!";
		argolasText.text = "";
		healthText.text = "";
	}

	void PlayerWins ()
	{
		playersTurn = false;
		spawnRings = false;
		gameOver = true;
		timerText.text = "";
		levelText.text = "Parabéns, você venceu!\nArgolas: " + argolas;
		argolasText.text = "";
		healthText.text = "";
	}

	void OnLevelWasLoaded(int index)
	{
		level++;
		InitGame();
    }

	void SetArgolasText()
	{
		argolasText.text = "Argolas: " + argolas.ToString ();
	}
    //define as argolas erradas
    void SetErrosText()
    {
        errosText.text = "Erros: " + erros.ToString();
    }


    IEnumerator CountDown()
	{
        //Debug.Log(KinectManager.aux);
        //yield return new WaitUntil(KinectManager.aux.iniciar = true);
        if (KinectManager.IsKinectInitialized()) {
            System.Func<bool> playerDetected = new System.Func<bool>(KinectManager.Instance.IsUserDetected);
            yield return new WaitUntil(playerDetected);
        }
        yield return new WaitForSeconds(1);
        levelText.text = "3";
        yield return new WaitForSeconds(1);
        levelText.text = "2";
        yield return new WaitForSeconds(1);
        levelText.text = "1";
        yield return new WaitForSeconds(1);
        levelText.text = "Vá!";
        yield return new WaitForSeconds(1);
        levelText.text = "";

        playersTurn = true;
    }

	public void GoBack()
	{
		playersTurn = false;
		spawnRings = false;
		argolas = 0;
		minutes = startMinutes;
		seconds = 59;
		controlPanel.SetActive(false);

//		SceneManager.UnloadScene("Game");
		SceneManager.LoadScene ("StartMenu");
	}

	public void StopGame()
	{
		playersTurn = false;
		spawnRings = false;

		//desabilitar botao de parar
		//habilitar botao de continuar
	}

	public void ContinueGame()
	{
		playersTurn = true;
		spawnRings = true;

		//desabilitar botao de continuar
		//habilitar botao de parar
	}

	public void RestartGame()
	{
		playersTurn = false;
		spawnRings = false;
		argolas = 0;
		minutes = startMinutes;
		seconds = 59;
		controlPanel.SetActive(false);

		//voltar com player e camera para o inicio
		InitGame();
	}
}


//load level every 60 s
//float timer = 60;
//void FixedUpdate () {
//	timer -= 1 * Time.deltaTime ;
//	print (timer);
//	if (timer <= 0)
//	{
//		Application.LoadLevel(0);
//	}
//}