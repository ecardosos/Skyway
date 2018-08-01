using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour{
	public GameObject PlayerObject;
	private Vector3 initTerrain = new Vector3(0,-100,0);
	private GameObject _terrain;
	private GameObject oldTerrain = null;
	private GameObject newTerrain = null;
	private int lineOfSigth = 1000;
	private int terrainHeigth = 450; //informacoes setadas nos terrenos
	private int heigthCorrection = -100;
	private int terrainWidth = 1500;
	private int numLoop = 0; //quantos loops na mesma fase ja foram feitos, usado para calcular o deslocamento do novo terreno em relacao a origem
	private int terrainLength =1500*3; // *3 porque estou buscando os prefabs que sao a combinaçao de 3 terrenos de 1500
	// talvez ajustar a velocidade seja uma boa os ter

	void Start(){
		_terrain = Resources.Load("Nivel"+GameManager.level+"/Nivel"+GameManager.level) as GameObject;
		oldTerrain = (GameObject)GameObject.Instantiate(_terrain, initTerrain, Quaternion.identity); //instancia o terreno 
		numLoop++;
	}

	void Update(){
		Vector3 playerPosition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y, PlayerObject.transform.position.z); //Posicao da asa delta
		// if(GameManager.gametype == porLvl){ //verificar o tipo de sessao, progressiva ou por lvl
		// 
		//Debug.Log(terrainLength*numLoop-lineOfSigth);
		if((playerPosition.z > (terrainLength*numLoop-lineOfSigth)) && (newTerrain == null)){
			newTerrain = (GameObject)GameObject.Instantiate(_terrain, new Vector3(0,heigthCorrection,terrainLength*numLoop), Quaternion.identity); //instancia o novo terreno 
			numLoop++;
		}

		if(playerPosition.z > (terrainLength*(numLoop-1)) && newTerrain != null){ // destroi o terreno anterior
			Destroy(oldTerrain);
			// Debug.Log("Destruction Time!!!");
			oldTerrain = newTerrain;
			newTerrain = null;
		}
		//} 
		//if(GameManager.gametype == progressivo){ //verificar o tipo de sessao, progressiva ou por lvl
		//  corrigir o caso do lvl 5 nao ter um proximo nivel
		//  Lembrar que para conectar os terrenos de nivel diferentes niveis e nesse sario utilizar um terreno de link 
		//  boa sorte o/
		// 	if((playerPosition.z > (terrainLength*numLoop-lineOfSigth)) && (newTerrain == null) && (linkTerrain == null)){
		//		linkTerrain = (GameObject)GameObject.Instantiate(Resources.Load("Links/"+GameManager.level+"-"+GameManager.level+1), new Vector3(0,-100,terrainLength*numLoop), Quaternion.identity);
		//		//numLoop++;
		//  }
		//}
	}
		

}