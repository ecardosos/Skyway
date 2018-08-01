using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    //camera
    public Camera cam1;
    public Camera cam2;

    //public Text countText;
    public float turn_speed = 3;
	public float flight_speed = 5;
	public GameObject center;
	public GameObject head;
	public GameObject helice;
    //public GameObject parede = GameObject.Find("Parede");
    public float x;
	public float multiplicadorX;
	public float multiplicadorY;
	float moveHorizontal;
	float moveVertical;

    //---------MODIFICACOES----------//
    public Text timerTextWall;
    private float startTime;
    private bool count = false;
    //---------MODIFICACOES----------//

    //-------------Modificações finais--------------//
    public GameObject player;
    public float xPlayerPosition;
    //-------------Modificações finais--------------//

    private Rigidbody rb;
	bool knt;
    public Interface interfc;
	Parametro parametro;
	public float initialX;
	public float initialY;
	public float initialZ;
	public Save save;

    // Use this for initialization
    void Start () 
	{
        //-----camera------//
        cam1.enabled = true;
        cam2.enabled = false;
        //-----------------//
		initialX = gameObject.transform.position.x;
		initialY = gameObject.transform.position.y;
		initialZ = gameObject.transform.position.z;
        interfc = GameObject.Find("Preferencias").GetComponent<Interface>();
        flight_speed = interfc.veloc;
   //     turn_speed = flight_speed - 2;
        rb = GetComponent<Rigidbody> ();

		parametro = GameObject.Find ("DataCollector").GetComponent<Parametro> ();
	}

	// Update is called once per frame
	void Update () 
	{

        //Camera
        if(Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }

        //----------MODIFICACOES------------//
        if (count == false)
        {
            startTime = Time.time;
        }
        //----------MODIFICACOES------------//

        if (!GameManager.instance.playersTurn) return;

		helice.transform.Rotate(0.0f, -flight_speed * 100 * Time.deltaTime, 0.0f);

		Vector3 rotation;
		if (KinectManager.IsKinectInitialized ()) {

            if (Interface.instance.yToggle)
            {
                
                float y = center.transform.position.z - head.transform.position.z; //diferença de profundidade 
                float movmenty = y * multiplicadorY;

                if (movmenty > turn_speed)
                {
                    moveVertical = -(turn_speed);
                }
                else if (movmenty < turn_speed * -1)
                {
                    moveVertical = -(turn_speed * -1);
                }
                else
                {
                    moveVertical = movmenty;
                }
                moveVertical = -movmenty;
            }
            else
            {
                x = head.transform.position.x - center.transform.position.x;
                //Debug.Log("X = " + x);
                float movmentx = x * multiplicadorX;
                if (movmentx > turn_speed)
                {
                    moveHorizontal = turn_speed;
                }
                else if (movmentx < turn_speed * -1)
                {
                    moveHorizontal = turn_speed * -1;
                }
                else
                {
                    moveHorizontal = movmentx;
                }
            }
        }
        else {
            //Debug.Log("test");
			moveHorizontal = turn_speed * Input.GetAxis ("Horizontal");
			moveVertical = -turn_speed * Input.GetAxis ("Vertical");
		}
		float rotateVertical = -2 * moveVertical;

		if (Interface.instance.yToggle) {
            rotation = new Vector3 (5 * rotateVertical, moveVertical, 1.0f);
			moveHorizontal = 0f;
            //Debug.Log(rotation + "-" + moveVertical);
		}
		else {
			rotation = new Vector3 (1.0f, moveHorizontal, 5 * -moveHorizontal);
			moveVertical = 0f;
            //Debug.Log(rotation + "-" + moveHorizontal);
            
		}

		Vector3	movement = new Vector3 (moveHorizontal, moveVertical, 0.0f) * Time.deltaTime;

		transform.Translate (flight_speed * Vector3.forward * Time.deltaTime, Space.World);
		transform.Translate(movement, Space.World);
        
		transform.localEulerAngles = rotation;                      // Aplicaçao da rotaçao sobre o modelo

        //Debug.Log(this.gameObject.transform.position.z - pos);
        //Debug.Log(GameManager.instance.erros);

        //-------------Modificações finais--------------//
        //xPlayerPosition = player.transform.position.x;
        //print(xPlayerPosition);

        //if(xPlayerPosition > -2.5f && xPlayerPosition < 2.5f)
        //{
        //    print(xPlayerPosition + "Faixa 2");
        //}
        //else if (xPlayerPosition > -7.5 && xPlayerPosition < -2.5f)
        //{
        //    print(xPlayerPosition + "Faixa 1");
        //}
        //else if (xPlayerPosition > 2.5f && xPlayerPosition < 7.5f)
        //{
        //    print(xPlayerPosition + "Faixa 3");
        //}
        
        //-------------Modificações finais--------------//
    }

    void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("Argola"))
		{
			GameManager.instance.argolas++;
            GameManager.instance.imagemAcerto.enabled = true;
            StartCoroutine("contagemImagem");
			if (GameManager.instance.playerHealth < 100) {
				GameManager.instance.playerHealth += 20;
			}
			Destroy (other.gameObject);
            Destroy(GameObject.FindWithTag("Parede"));
            parametro.ponto = 1;
		}

        if(other.gameObject.CompareTag("Parede"))
        {
            GameManager.instance.erros += 1;
            GameManager.instance.imagemErro.enabled = true;
            Destroy(other.gameObject);
            StartCoroutine("contagemImagem");
        }
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Wall")) 
		{
			rb.freezeRotation = true;
		}
	}
    
    //-------------MODIFICACOES------------//
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") && (moveHorizontal == 3 || moveHorizontal == -3 || moveVertical == 3 || moveVertical == -3))
        {
            //Starts counting when player hits any wall
            count = true;
            float t = Time.time - startTime;

            //string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            //Debug.Log("Teste");
            //StartCoroutine("CountDown");
            //timerTextWall.text = "Volte à sua posição normal\n" + seconds;
            //sets time limit to be touching the wall
            if (t % 60 >= 5)
            {
                timerTextWall.text = "Volte à sua posição normal!";
            }
        }
        else if (other.gameObject.CompareTag("Wall") && moveHorizontal == 0)
        {
            count = false;
            timerTextWall.text = "";
        }
    }

    //resets timer to zero when leaving the wall
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            count = false;
            timerTextWall.text = "";
        }
    }

    IEnumerator contagemImagem()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.imagemAcerto.enabled = false;
        GameManager.instance.imagemErro.enabled = false;
    }


}


