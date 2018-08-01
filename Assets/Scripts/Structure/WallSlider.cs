using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WallSlider : MonoBehaviour
{

    public GameObject player;

    private float speed;

    // Use this for initialization
    void Start()
    {
        speed = player.gameObject.GetComponent<PlayerController>().flight_speed;
        //timerTextWall.GetComponent<Renderer>().enabled = false;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameManager.instance.playersTurn) return;
        transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.World);
    }
}


