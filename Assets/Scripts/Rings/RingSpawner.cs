using UnityEngine;
using System.Collections;

public class RingSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject argola;
    //public GameObject lastArgola;
    public float zPosition;
    public float xPosition;
    public float xPositionRing;

    public float spawnTime = 3f;
    public float xy_offset = 5;
    public float z_offset = 50;
    public Interface interfc;
    public float playerXPosition;
    public float[,] matriz = new float[5, 5];
    public float[,] matriz1 = new float[5, 5];
    public float[,] matriz2 = new float[5, 5];
    public float[,] matriz3 = new float[5, 5];
    public float[,] matriz4 = new float[5, 5];
    public float[,] matriz5 = new float[5, 5];
    public float somaPeso;
    public float escolhido;
    public float posicaoEscolhida = -1;
    public int c;

    void Start()
    {
        interfc = GameObject.Find("Preferencias").GetComponent<Interface>();
        player = GameObject.Find("Player");
        z_offset = interfc.distz;
        xy_offset = interfc.distx;
        InvokeRepeating("SpawnRing", spawnTime, spawnTime);
        //lastArgola.transform.position = player.transform.position;
        zPosition = player.transform.position.z;



        matriz1[0, 0] = 5;
        matriz1[1, 0] = 4;
        matriz1[2, 0] = 3;
        matriz1[3, 0] = 2;
        matriz1[4, 0] = 1;
        matriz1[0, 1] = 4;
        matriz1[1, 1] = 5;
        matriz1[2, 1] = 4;
        matriz1[3, 1] = 3;
        matriz1[4, 1] = 2;
        matriz1[0, 2] = 3;
        matriz1[1, 2] = 4;
        matriz1[2, 2] = 5;
        matriz1[3, 2] = 4;
        matriz1[4, 2] = 3;
        matriz1[0, 3] = 2;
        matriz1[1, 3] = 3;
        matriz1[2, 3] = 4;
        matriz1[3, 3] = 5;
        matriz1[4, 3] = 4;
        matriz1[0, 4] = 1;
        matriz1[1, 4] = 2;
        matriz1[2, 4] = 3;
        matriz1[3, 4] = 4;
        matriz1[4, 4] = 5;

        matriz2[0, 0] = 4;
        matriz2[1, 0] = 5;
        matriz2[2, 0] = 4;
        matriz2[3, 0] = 3;
        matriz2[4, 0] = 2;
        matriz2[0, 1] = 5;
        matriz2[1, 1] = 4;
        matriz2[2, 1] = 5;
        matriz2[3, 1] = 3;
        matriz2[4, 1] = 2;
        matriz2[0, 2] = 3;
        matriz2[1, 2] = 5;
        matriz2[2, 2] = 1;
        matriz2[3, 2] = 4;
        matriz2[4, 2] = 3;
        matriz2[0, 3] = 2;
        matriz2[1, 3] = 3;
        matriz2[2, 3] = 5;
        matriz2[3, 3] = 4;
        matriz2[4, 3] = 5;
        matriz2[0, 4] = 1;
        matriz2[1, 4] = 2;
        matriz2[2, 4] = 3;
        matriz2[3, 4] = 5;
        matriz2[4, 4] = 4;

        matriz3[0, 0] = 3;
        matriz3[1, 0] = 4;
        matriz3[2, 0] = 5;
        matriz3[3, 0] = 2;
        matriz3[4, 0] = 1;
        matriz3[0, 1] = 4;
        matriz3[1, 1] = 3;
        matriz3[2, 1] = 4;
        matriz3[3, 1] = 5;
        matriz3[4, 1] = 4;
        matriz3[0, 2] = 5;
        matriz3[1, 2] = 4;
        matriz3[2, 2] = 3;
        matriz3[3, 2] = 4;
        matriz3[4, 2] = 5;
        matriz3[0, 3] = 3;
        matriz3[1, 3] = 5;
        matriz3[2, 3] = 4;
        matriz3[3, 3] = 3;
        matriz3[4, 3] = 4;
        matriz3[0, 4] = 1;
        matriz3[1, 4] = 2;
        matriz3[2, 4] = 5;
        matriz3[3, 4] = 4;
        matriz3[4, 4] = 3;

        matriz4[0, 0] = 2;
        matriz4[1, 0] = 3;
        matriz4[2, 0] = 4;
        matriz4[3, 0] = 5;
        matriz4[4, 0] = 4;
        matriz4[0, 1] = 3;
        matriz4[1, 1] = 2;
        matriz4[2, 1] = 3;
        matriz4[3, 1] = 4;
        matriz4[4, 1] = 5;
        matriz4[0, 2] = 4;
        matriz4[1, 2] = 3;
        matriz4[2, 2] = 2;
        matriz4[3, 2] = 3;
        matriz4[4, 2] = 4;
        matriz4[0, 3] = 5;
        matriz4[1, 3] = 4;
        matriz4[2, 3] = 3;
        matriz4[3, 3] = 2;
        matriz4[4, 3] = 3;
        matriz4[0, 4] = 4;
        matriz4[1, 4] = 5;
        matriz4[2, 4] = 4;
        matriz4[3, 4] = 3;
        matriz4[4, 4] = 2;

        matriz5[0, 0] = 1;
        matriz5[1, 0] = 2;
        matriz5[2, 0] = 3;
        matriz5[3, 0] = 4;
        matriz5[4, 0] = 5;
        matriz5[0, 1] = 2;
        matriz5[1, 1] = 1;
        matriz5[2, 1] = 2;
        matriz5[3, 1] = 3;
        matriz5[4, 1] = 4;
        matriz5[0, 2] = 3;
        matriz5[1, 2] = 2;
        matriz5[2, 2] = 1;
        matriz5[3, 2] = 2;
        matriz5[4, 2] = 3;
        matriz5[0, 3] = 4;
        matriz5[1, 3] = 3;
        matriz5[2, 3] = 2;
        matriz5[3, 3] = 1;
        matriz5[4, 3] = 2;
        matriz5[0, 4] = 5;
        matriz5[1, 4] = 4;
        matriz5[2, 4] = 3;
        matriz5[3, 4] = 2;
        matriz5[4, 4] = 1;

    }


    void SpawnRing()
    {
        if (GameManager.instance.spawnRings)
        {
            //    int pos = Random.Range (1, 4);

            //    if (GameManager.instance.y_axis) {
            //        if (pos == 1)
            //            InstantiateAtTop (z_offset);
            //        else if (pos == 2)
            //            InstantiateAtCenter (z_offset);
            //        else
            //            InstantiateAtBottom (z_offset);
            //    } else {
            //        if (pos == 1)
            //            InstantiateAtLeft (z_offset);
            //        else if (pos == 2)
            //            InstantiateAtCenter (z_offset);
            //        else
            //            InstantiateAtRight (z_offset);
            //    }


            //     for (int i = 0; i < 3; i++) {
            //    for (int j = 0; j < 3; j++) {
            //        //print(matriz[i, j]);
            //    }
            //}

            if (Interface.dif == 1)
            {
                print("Muito facil");
                matriz = matriz1;
            }
            else if (Interface.dif == 2)
            {
                print("Facil");
                matriz = matriz2;
            }
            else if (Interface.dif == 3)
            {
                print("Medio");
                matriz = matriz3;
            }
            else if (Interface.dif == 4)
            {
                print("Dificil");
                matriz = matriz4;
            }
            else if (Interface.dif == 5)
            {
                print("Muito dificil");
                matriz = matriz5;
            }
            somaPeso = 0;
            posicaoEscolhida = -1;
            playerXPosition = player.transform.position.x;

            print(playerXPosition);

            if (playerXPosition > -3 && playerXPosition < 3)
            {
                c = 0;
                print("faixa3");

                for (int i = 0; i < 5; i++)
                {
                    somaPeso += matriz[i, 2];
                }

                escolhido = Random.Range(0, somaPeso);
                print("escolhido: " + escolhido);

                while (escolhido > 0)
                {
                    escolhido -= matriz[c, 2];
                    c++;
                    posicaoEscolhida++;
                }

                if (posicaoEscolhida == 0)
                    InstantiateAtMostLeft(z_offset);
                else if (posicaoEscolhida == 1)
                    InstantiateAtLeft(z_offset);
                else if (posicaoEscolhida == 2)
                    InstantiateAtCenter(z_offset);
                else if (posicaoEscolhida == 3)
                    InstantiateAtRight(z_offset);
                else if (posicaoEscolhida == 4)
                    InstantiateAtMostRight(z_offset);

                print(escolhido + "----" + posicaoEscolhida);

            }
            else if (playerXPosition <= -3 && playerXPosition >= -8)
            {
                c = 0;
                print("faixa2");

                for (int i = 0; i < 5; i++)
                {
                    somaPeso += matriz[i, 1];
                }

                escolhido = Random.Range(0, somaPeso);
                print("escolhido: " + escolhido);

                while (escolhido > 0)
                {
                    escolhido -= matriz[c, 1];
                    c++;
                    posicaoEscolhida++;
                }

                if (posicaoEscolhida == 0)
                    InstantiateAtMostLeft(z_offset);
                else if (posicaoEscolhida == 1)
                    InstantiateAtLeft(z_offset);
                else if (posicaoEscolhida == 2)
                    InstantiateAtCenter(z_offset);
                else if (posicaoEscolhida == 3)
                    InstantiateAtRight(z_offset);
                else if (posicaoEscolhida == 4)
                    InstantiateAtMostRight(z_offset);
                print(escolhido + "----" + posicaoEscolhida);
            }
            else if (playerXPosition < -8)
            {
                c = 0;
                print("faixa0");

                for (int i = 0; i < 5; i++)
                {
                    somaPeso += matriz[i, 0];
                }

                escolhido = Random.Range(0, somaPeso);
                print("escolhido: " + escolhido);

                while (escolhido > 0)
                {
                    escolhido -= matriz[c, 0];
                    c++;
                    posicaoEscolhida++;
                }
                if (posicaoEscolhida == 0)
                    InstantiateAtMostLeft(z_offset);
                else if (posicaoEscolhida == 1)
                    InstantiateAtLeft(z_offset);
                else if (posicaoEscolhida == 2)
                    InstantiateAtCenter(z_offset);
                else if (posicaoEscolhida == 3)
                    InstantiateAtRight(z_offset);
                else if (posicaoEscolhida == 4)
                    InstantiateAtMostRight(z_offset);
                print(escolhido + "----" + posicaoEscolhida);

            }
            else if (playerXPosition > 8)
            {
                c = 0;
                print("faixa5");

                for (int i = 0; i < 5; i++)
                {
                    somaPeso += matriz[i, 4];
                }

                escolhido = Random.Range(0, somaPeso);
                print("escolhido: " + escolhido);

                while (escolhido > 0)
                {
                    escolhido -= matriz[c, 4];
                    c++;
                    posicaoEscolhida++;
                }
                if (posicaoEscolhida == 0)
                    InstantiateAtMostLeft(z_offset);
                else if (posicaoEscolhida == 1)
                    InstantiateAtLeft(z_offset);
                else if (posicaoEscolhida == 2)
                    InstantiateAtCenter(z_offset);
                else if (posicaoEscolhida == 3)
                    InstantiateAtRight(z_offset);
                else if (posicaoEscolhida == 4)
                    InstantiateAtMostRight(z_offset);

                print(escolhido + "----" + posicaoEscolhida);
            }
            else if (playerXPosition >= 3 && playerXPosition <= 8)
            {
                c = 0;
                print("faixa4");

                for (int i = 0; i < 5; i++)
                {
                    somaPeso += matriz[i, 3];
                }

                escolhido = Random.Range(0, somaPeso);
                print("escolhido: " + escolhido);

                while (escolhido > 0)
                {
                    escolhido -= matriz[c, 3];
                    c++;
                    posicaoEscolhida++;
                }
                if (posicaoEscolhida == 0)
                    InstantiateAtMostLeft(z_offset);
                else if (posicaoEscolhida == 1)
                    InstantiateAtLeft(z_offset);
                else if (posicaoEscolhida == 2)
                    InstantiateAtCenter(z_offset);
                else if (posicaoEscolhida == 3)
                    InstantiateAtRight(z_offset);
                else if (posicaoEscolhida == 4)
                    InstantiateAtMostRight(z_offset);
                print(escolhido + "----" + posicaoEscolhida);
            }
        }
    }

    void Update()
    {


        //---------ROLETA----------//

    }

    // Create ring at center
    void InstantiateAtCenter(float offset)
    {
        //Instantiate(argola, new Vector3 (0.0f, 30.5f, lastArgola.transform.position.z + offset), Quaternion.AngleAxis(270, Vector3.left));

        Instantiate(argola, new Vector3(0.0f, 30.5f, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }

    // Create ring at top
    void InstantiateAtTop(float offset)
    {
        //Instantiate (argola, new Vector3 (0.0f, 30.5f + xy_offset, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(0.0f, 30.5f + xy_offset, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }

    // Create ring at bottom
    void InstantiateAtBottom(float offset)
    {
        //Instantiate (argola, new Vector3 (0.0f, 30.5f - xy_offset, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(0.0f, 30.5f - xy_offset, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }

    // Create ring at left
    void InstantiateAtLeft(float offset)
    {
        //Instantiate (argola, new Vector3 (-xy_offset, 30.5f, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(-xy_offset, 30.5f, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }

    void InstantiateAtMostLeft(float offset)
    {
        //Instantiate (argola, new Vector3 (-xy_offset, 30.5f, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(-xy_offset * 2, 30.5f, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }

    void InstantiateAtMostRight(float offset)
    {
        //Instantiate (argola, new Vector3 (-xy_offset, 30.5f, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(xy_offset * 2, 30.5f, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }
    // Create ring at right
    void InstantiateAtRight(float offset)
    {
        //Instantiate (argola, new Vector3 (xy_offset, 30.5f, lastArgola.transform.position.z + offset), Quaternion.AngleAxis (270, Vector3.left));

        Instantiate(argola, new Vector3(xy_offset, 30.5f, zPosition + offset), Quaternion.AngleAxis(270, Vector3.left));
        zPosition = zPosition + offset;
    }
}