using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ring : MonoBehaviour {

	private GameObject player;
	private bool missed = false;
	public Interface interfc;
	public float vision;
	Parametro parametro;
	Save save;

	void Start ()
	{
		player = GameObject.Find ("Player");
		interfc = GameObject.Find("Preferencias").GetComponent<Interface>();
        gameObject.GetComponent<Renderer>().enabled = false;
		vision = interfc.distz * interfc.visArg;
		parametro = GameObject.Find ("DataCollector").GetComponent<Parametro> ();
		InvokeRepeating ("updateData", 0.1f, 0.1f);

	}
	// Update is called once per frame
	void Update ()
	{
		if (this.gameObject.transform.position.z - player.transform.position.z < vision) {
			gameObject.GetComponent<Renderer> ().enabled = true;
		}
			
		CheckMissedRing ();
		if (this.gameObject.transform.position.z < Camera.main.transform.position.z - 10) {
			//save.salvar (parametro.jogador, parametro.parametros, parametro.url);
			//parametro.parametros = new List<Dado> ();
			Destroy (this.gameObject);
		}
        
	}
	void CheckMissedRing ()
	{
		if (this.transform.position.z - player.transform.position.z < 2 && !missed) {

			GameManager.instance.playerHealth -= 20;
			missed = true;
		}
        //Debug.Log(this.transform.position.z - player.transform.position.z + "   " + missed);
    }
	void updateData(){
		if (this.gameObject.transform.position.z - player.transform.position.z <= interfc.distz && this.gameObject.transform.position.z - player.transform.position.z > 0) {
			parametro.distX = gameObject.transform.position.x - player.transform.position.x;
			parametro.distZ = gameObject.transform.position.z - player.transform.position.z;
			parametro.ponto = 0;
		} else {
			if (gameObject.transform.position.z < Camera.main.transform.position.z+(player.transform.position.z - Camera.main.transform.position.z)) {
				parametro.ponto = -1;
				CancelInvoke ();
			}
		}
	}
}
