using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    [SerializeField]
    GameObject colectavel;

    [SerializeField]
    Transform[] coordenadas = new Transform[5];

    private int sorteado = 0;
    public bool instanciar = true;

    [SerializeField]
    float temporizador = 10;
    private bool contaTempo = true;
    [SerializeField]
    Text mostrador;
    
    // Update is called once per frame
    void Update()
    {
        ContadorTempo();
        if (instanciar)
        {
            instanciar = false;
            //podemos instanciar a criação de cada um dos colectaveis entre 1 a 3 segundos utilizando a função Invoke
            Invoke("InstanciaColectavel", Random.Range(1, 3));
        }
    }
    void InstanciaColectavel()
    {
        sorteado = sorteio(0, 4);
        Instantiate(colectavel, coordenadas[sorteado].position, Quaternion.identity);
    }

    int sorteio(int minimo, int maximo)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        return minimo + (sorteado - minimo + Random.Range(1, maximo - minimo)) % (maximo - minimo);
    }

    void ContadorTempo()
    {
        MostraTempo(temporizador);
        if (contaTempo)
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;
            }
            else
            {
                temporizador = 0;
                contaTempo = false;
                Interface.gameover = true;
            }
        }
    }

    // função para mostrar tempo na interface gráfica
    void MostraTempo(float relogio)
    {
        float minutos = Mathf.FloorToInt(relogio / 60);
        float segundos = Mathf.FloorToInt(relogio % 60);

        mostrador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
