using System.Collections;
using UnityEngine;

public class AtirarLaser : MonoBehaviour
{
    public GameObject laser; //O laser que será criado pela nave
    public float fireRate; //Tempo de tiro da nave
    private float tempoEspera; //Tempo de espera para o proximo tiro
    public int nivelLaser = 1;
    public int nivelPoderLaser = 0;
    public AudioPlayer audioPlayer;

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

        //Definir o poder do laser instanciado
        novoLaserEsquerda.GetComponent<PoderLaser>().DefinirPoderLaser(nivelPoderLaser);


        //Instanciar o laser na direita
        GameObject novoLaserDireita = Instantiate(laser);
        novaPosicao = transform.position + new Vector3(x*-1, y, 0);
        novoLaserDireita.transform.position = novaPosicao;

        //Definir o poder do laser instanciado
        novoLaserDireita.GetComponent<PoderLaser>().DefinirPoderLaser(nivelPoderLaser);
    }

    private void Atirar()
    {
        //Tocar o audio do laser
        audioPlayer.TocarAudioLaser();

        //Instanciar o laser no jogo
        GameObject novoLaser = Instantiate(laser);

        //Definir o poder do laser instanciado
        novoLaser.GetComponent<PoderLaser>().DefinirPoderLaser(nivelPoderLaser);

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

    public void HabilitarNivelLaser(int nivel)
    {
        //Atribuir o nivel do poder do laser
        nivelPoderLaser = nivel;

        //Parar todas as coroutines que estejam executando do script
        StopAllCoroutines();

        //Contar um tempo para poder voltar ao laser normal
        StartCoroutine(ReiniciarPoderLaser());
    }

    IEnumerator ReiniciarPoderLaser()
    {
        //Esperar 3 segundos para poder resetar o laser
        yield return new WaitForSeconds(3f);

        //Resetar o nivel do poder do laser
        nivelPoderLaser = 0;
    }
}
