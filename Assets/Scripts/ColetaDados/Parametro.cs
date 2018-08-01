using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parametro : MonoBehaviour {

    public Interface interfc;
	public CubemanController cManController;
    public string url;
    public List<Dado> parametros;
    private GameObject player;
	//public float xHead;
	//public float yHead;
	//public float xCenter;
	//public float yCenter;
	public float distX;
	public float distZ;
	public int ponto;
	public float angulo = 0f;
    public Player jogador;
	public Save save;

	//IDList: {"angulo":4,"distZ":5,"distX":6,"ponto":7}
	// Use this for initialization
	void Start () {
		save = new Save ();
		interfc = GameObject.Find("Preferencias").GetComponent<Interface>();
		jogador = new Player (){ id = interfc.pacienteID, interacao = interfc.sessaoPaciente };
		parametros = new List<Dado> ();     
        url = interfc.url;
        player = GameObject.Find("Player");
		cManController = GameObject.Find ("Cuberman").GetComponent<CubemanController> ();
		//InvokeRepeating ("updateData", 0.1f, 0.1f);
		StartCoroutine("starGetData");
    }
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver && !save.saved) {
			StopCoroutine ("starGetData");
			saveData ();
			//if (!save.success) {
			//	saveData ();
			//}
		}
		if(Input.GetKeyDown(KeyCode.P)){
			print ("Save>>>>>>");
			saveData (); 
		}

    }

	//public void getAngulo(){
        //		float produtoEscalar = (xCenter * xHead) + (50 * yHead);
        //		float moduloHead = Mathf.Sqrt ((xHead * xHead) + (yHead * yHead));
        //		float moduloCenter = Mathf.Sqrt ((xCenter * xCenter) + (50 * 50));
        //		float cossAngulo = produtoEscalar / ((moduloHead) * (moduloCenter));
        // 		float angulo = Mathf.Acos (cossAngulo);
        //Vector3 head = new Vector3(xHead - xCenter, yHead - yCenter);
        //Vector3 center = new Vector3(xCenter - xCenter, 50f - yCenter);
        //Vector3 test = new Vector3(0, 1);
        //Vector3 test2 = new Vector3(0, 0);
        //Debug.Log(Vector3.Angle(test, test2));
        //this.angulo = Vector3.Angle(center, head);
   // }

    float getAngleSpine( Vector3 head, Vector3 center ) {
        return (Mathf.Atan2(head.x - center.x, head.y - center.y) * 180f) / Mathf.PI;//EmGraus
    }

    void updateData()
    {
        if (KinectManager.IsKinectInitialized())
        {
            if (KinectManager.Instance.IsUserDetected())
             {
                //xHead = cManController.Shoulder_Center.transform.position.x;
                //yHead = cManController.Shoulder_Center.transform.position.y;
                //xCenter = cManController.Hip_Center.transform.position.x;
                //yCenter = cManController.Hip_Center.transform.position.y;

                Vector3 head = new Vector3(cManController.Shoulder_Center.transform.position.x, cManController.Shoulder_Center.transform.position.y);
                Vector3 center = new Vector3(cManController.Hip_Center.transform.position.x, cManController.Hip_Center.transform.position.y);

                getAngleSpine(head, center);
                Debug.Log(getAngleSpine(head, center));
                //getAngulo();
                parametros.Add(new Dado() { id = 4, valor = "" + angulo, timestamp = (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalMilliseconds });
                parametros.Add(new Dado() { id = 5, valor = "" + distZ, timestamp = (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalMilliseconds });
                parametros.Add(new Dado() { id = 6, valor = "" + distX, timestamp = (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalMilliseconds });
                parametros.Add(new Dado() { id = 7, valor = "" + ponto, timestamp = (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalMilliseconds });
                //print(ponto);
                //Debug.Log(angulo);
            }
        }
    }

	void saveData(){
		save.salvar (jogador, parametros, url);
	}

	IEnumerator starGetData(){
		InvokeRepeating ("updateData",0.1f,0.1f);
		yield return null;
	}
		
}