using UnityEngine;

public class AtirarLaserInimigo : MonoBehaviour
{
    public GameObject laserInimigo;
    public float tempoDeTiro;
    private float tempoDeEspera = 0;

    // Update is called once per frame
    void Update()
    {
        //Verificar o tempo para poder atirar
        if(Time.time > tempoDeEspera)
        {
            //Instanciar o laser inimigo
            GameObject novoLaser = Instantiate(laserInimigo);

            //Posicionar o laser no inimigo
            novoLaser.transform.position = transform.position;
            novoLaser.transform.rotation = transform.rotation;

            //Atualizar o tempo de espera para o proximo tiro
            tempoDeEspera = Time.time + tempoDeTiro; 
        }
    }
}
