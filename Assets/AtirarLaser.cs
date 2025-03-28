using UnityEngine;

public class AtirarLaser : MonoBehaviour
{
    public GameObject laser; //O laser que será criado pela nave
    public float fireRate; //Tempo de tiro da nave
    private float tempoEspera; //Tempo de espera para o proximo tiro

    // Update is called once per frame
    void Update()
    {
        //Verificar se a nave pode atirar
        if(Time.time > tempoEspera)
        {
            //Atualizar o tempo de espera para atirar
            tempoEspera = Time.time + fireRate;

            //Instanciar o laser no jogo
            GameObject novoLaser = Instantiate(laser);

            //Posiciona o laser na frente da nave
            novoLaser.transform.position = transform.position + Vector3.up;
        }
    }
}
