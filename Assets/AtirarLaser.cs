using UnityEngine;

public class AtirarLaser : MonoBehaviour
{
    public GameObject laser; //O laser que será criado pela nave
    public float fireRate; //Tempo de tiro da nave
    private float tempoEspera; //Tempo de espera para o proximo tiro
    public int nivelLaser = 1;

    // Update is called once per frame
    void Update()
    {
        //Verificar se a nave pode atirar
        if(Time.time > tempoEspera)
        {
            //Atualizar o tempo de espera para atirar
            tempoEspera = Time.time + fireRate;

            //Atirar o laser
            Atirar();
        }
    }

    public void AumentarNivel()
    {
        //Incrementar um valor na variavel nivel
        nivelLaser++;

        //Verificar se chegou ao nível máximo e arredondar para 5
        nivelLaser = nivelLaser > 5 ? 5 : nivelLaser;
    }

    public void RemoverNiveis()
    {
        //Retornar o nivel para 1
        nivelLaser = 1;
    }

    private void InstanciarLaserDuplo(float x, float y)
    {
        //Instanciar o laser na esquerda
        GameObject novoLaserEsquerda = Instantiate(laser);
        Vector3 novaPosicao = transform.position + new Vector3(x, y, 0);
        novoLaserEsquerda.transform.position = novaPosicao;

        //Instanciar o laser na direita
        GameObject novoLaserDireita = Instantiate(laser);
        novaPosicao = transform.position + new Vector3(x*-1, y, 0);
        novoLaserDireita.transform.position = novaPosicao;
    }

    private void Atirar()
    {
        //Instanciar o laser no jogo
        GameObject novoLaser = Instantiate(laser);

        //Posiciona o laser na frente da nave
        novoLaser.transform.position = transform.position + Vector3.up;

        //Verificar se a nave está no nivel 1
        if (nivelLaser == 1) return;

        //Instanciar os lasers do nivel 2
        InstanciarLaserDuplo(-0.195f, 0.851f);

        //Verificar se a nave está no nivel 2
        if(nivelLaser == 2) return;

        //Instanciar os lasers do nivel 3
        InstanciarLaserDuplo(-0.378f, 0.575f);

        //Verificar se a nave está no nivel 3
        if(nivelLaser == 3) return;

        //Instanciar os lasers do nivel 4
        InstanciarLaserDuplo(-0.572f, 0.323f);

        //Verificar se a nave está no nivel 4
        if (nivelLaser == 4) return;

        //Instanciar os lasers do nivel 5
        InstanciarLaserDuplo(-0.74f, -0.018f);
    }
}
