using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Save {
	public bool saved = false;
	//public string url = "http://localhost:8080/FrameWorkSG/Parametro/salvar";
	//void Start(){
	//	salvar(teste ());
	//}
	//Metodo salvar recebe como parametro uma variavel do tipo Dictionary<long,string>,
	//contendo os parametros para serem enviados.
	//a variavel Dictionary deve conter como chave, o id do parametro e
	//seu valor deve ser o valor a ser enviado. exemplo no metodo de teste ao final desta classe.
	
	public void salvar(Player player,List<Dado> parametros,string url){
		string subimitUrl = url + "Parametro/salvar";
		string json = "jsonData="+this.SaveToString(player, parametros);
		WWWForm form = new WWWForm ();
		form.AddField ("jsonData", this.SaveToString (player, parametros));
		Debug.Log(subimitUrl.ToString()+"");
		Debug.Log ("" + json);
		WWW www = new WWW (subimitUrl, form);
		//WWW www = new WWW (subimitUrl+"?"+json);
		//yield return www;
		this.save(www);
		saved = true;
		//if (!string.IsNullOrEmpty (www.error)) {
		//	print (www.error);
		//	success = false;
		//}else{
		//	print ("SUCCESS");
		//	success = true;
		//}
		//WWW www = new WWW (subimitUrl+"?"+json);
		//StartCoroutine (save (www));
	}

	// Este metodo e utilizado pelo metodo salvar

	public string SaveToString(Player player, List<Dado> parametros){
		JSONObject j = new JSONObject (JSONObject.Type.OBJECT);
		JSONObject a;
		JSONObject arr = new JSONObject (JSONObject.Type.ARRAY);
		j.AddField("playerId", player.id);
        j.AddField("gameId", 2);
		j.AddField("gameToken", "11eaf18333a6d665c82bb21ea4e68e5f");
		//j.AddField("timestamp", (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalMilliseconds);
		foreach(Dado dado in parametros){
			a = new JSONObject (JSONObject.Type.OBJECT);
			a.AddField("parametroId",dado.id);
			a.AddField("valor",dado.valor);
			a.AddField("timestamp", dado.timestamp);
			arr.Add (a);
		}
		j.AddField ("parametros", arr);
		string data = j.Print();
		return data;
	}


	//Este metodo e utilizado pelo metodo salvar
	IEnumerator save(WWW www) {
		yield return www;
		
		if(www.error == null) {
			Debug.Log("Form upload complete!");
			Debug.Log(www.error);
		}
		else {
			Debug.Log(www.error);
		}
	}


	//Metodo de teste---
	
	//public Dictionary<long,string> teste(){
	//	Dictionary<long,string> param = new Dictionary<long,string>();
	//	param.Add (1,"777");
	//	param.Add (2, "testevar01");
	//	param.Add (3, "testevar02");
	//	return param;
	//}
}
