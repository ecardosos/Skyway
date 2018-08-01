using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 		
public class Interface : MonoBehaviour {

    public static Interface instance = null;
    public bool xToggle;
	public bool yToggle;
	public float veloc;
	public float distz;
    public float distx;
	public int tempo;
	public int visArg;
	public string nomeFisio;
	public string nomePcnt;
    public string url;
    public string pacienteID;
    public string sessaoPaciente;
    public static int dif;

    public Dropdown myDropDown;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

	public void clicks ()
	{
	//	nomeFisio = GameObject.Find ("Text_Fisioterapeuta").GetComponent<Text> ().text;
	//	nomePcnt = GameObject.Find ("Text_Paciente").GetComponent<Text> ().text;
        pacienteID = GameObject.Find("Text_PacienteID").GetComponent<Text>().text;
        sessaoPaciente = GameObject.Find("Text_Sessao").GetComponent<Text>().text;
        Debug.Log(sessaoPaciente);
		url = GameObject.Find ("Text_URL").GetComponent<Text> ().text;
		xToggle = GameObject.Find ("X").GetComponent<Toggle> ().isOn;
		yToggle = GameObject.Find ("Y").GetComponent<Toggle> ().isOn;
        //Debug.Log(xToggle + "----" + yToggle);
        veloc = float.Parse(GameObject.Find ("Text_Velocidade").GetComponent<Text> ().text);
		tempo = int.Parse(GameObject.Find ("Text_Tempo").GetComponent<Text> ().text);
		distz = float.Parse(GameObject.Find ("Text_DistanciaZ").GetComponent<Text> ().text);
        distx = float.Parse(GameObject.Find("Text_DistanciaX").GetComponent<Text>().text);
        //url = GameObject.Find("Text_URL").GetComponent<Text> ().text;

		visArg = getNum ();
        dif = getDifNum();
        DontDestroyOnLoad(transform.gameObject);

		Application.LoadLevel ("Game");
    }

	private int getNum ()
	{
		ToggleGroup group = GameObject.Find ("Visao_argolas").GetComponent<ToggleGroup> ();
		string active = null;
		int actvNum;

		foreach (var item in group.ActiveToggles()) 
		{
			active = item.name;
			break;
		}

		actvNum = int.Parse(GameObject.Find (active).GetComponentInChildren<Text>().text);

		return actvNum;
	}

    private int getDifNum()
    {
        ToggleGroup group = GameObject.Find("Dificuldade").GetComponent<ToggleGroup>();
        string active = null;
        int actvNum;

        foreach (var item in group.ActiveToggles())
        {
            active = item.name;
            break;
        }

        actvNum = int.Parse(GameObject.Find(active).GetComponentInChildren<Text>().text);
        Debug.Log(actvNum);
        return actvNum;
    }

}
