using System.Collections;
using TMPro;
using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public TextMeshProUGUI txtPontuacao; //Variável para manipular o texto da pontuação
    private float pontuacao;//Variavel para armazenar a pontuacao do jogo

    public GameObject[] vidasPlayer; //Os GameObjects da vida do jogador
    private int vidaJogador; //A quantidade de vida atual do jogador

    public TextMeshProUGUI txtNivelJogo;
    public int nivelJogo;//Define o nivel dos inimigos no jogo
    public float tempoDificuldade;//tempo para aumentar o nivel do jogo
    
    private EscudoPlayer escudoPlayer;//Variavel com a informação do escudo do jogador

    public PainelVidaChefe painelVidaChefe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Zerar a pontuação quando o jogo começa
        pontuacao = 0;

        //Atualizar o texto da pontuação
        txtPontuacao.text = $"{pontuacao}";

        //Definir a quantidade de vidas que o jogador terá de inicio
        vidaJogador = vidasPlayer.Length;

        //Obter a referencia do escudo do player
        escudoPlayer = FindFirstObjectByType<EscudoPlayer>();

        //Definir o nivel 1
        nivelJogo = 1;

        //Atualizar texto
        txtNivelJogo.text = $"Nv. {nivelJogo}";

        //Iniciar contagem de nivel
        StartCoroutine(IncrementarDificuldade());

        //Ocultar a vida do chefe
        //OcultarVidaChefe();
    }

    public void IncrementarPontuacao(int pontuacao)
    {
        //Incrementar na variavel o ponto
        this.pontuacao += pontuacao;

        //Atualiza o texto da pontuação
        txtPontuacao.text = $"{this.pontuacao}";
    }

    public void DecrementarVidaJogador()
    {
        //Verificar se o jogador pode tomar dano
        if (escudoPlayer.estaAtivo == true) return;

        //Verificar se o jogador tem vidas
        if(vidaJogador == 1)
        {
            //Desabilitar a ultima vida
            vidasPlayer[0].SetActive(false);

            //Matar Jogador
            FindFirstObjectByType<DanoPlayer>().DestruirPlayer();
        }
        else
        {
            //Desabilitar uma imagem de vida do canvas
            vidasPlayer[vidaJogador-1].SetActive(false);

            //Decrementar uma vida do player
            vidaJogador--;

            //Reiniciar nivel da nave
            FindFirstObjectByType<AtirarLaser>().RemoverNiveis();
        }
    }

    IEnumerator IncrementarDificuldade()
    {
        //Repetir até que o nível seja o máximo
        while (true)
        {
            //Esperar um tempo para poder subir o nivel do jogo
            yield return new WaitForSeconds(tempoDificuldade);

            //Aumentar o nivel do jogo
            nivelJogo++;

            //Verificar se chegou no nivel máximo
            if (nivelJogo == 8) {
                //Atualizo o texo para o nível máximo
                txtNivelJogo.text = "Nv. Max";

                //Parar a repetição
                break;
            }

            //Atualizar o texto para o nivel atual
            txtNivelJogo.text = $"Nv. {nivelJogo}";
        }
    }

    /// <summary>
    /// Exibe a vida do chefe quando acionado
    /// </summary>
    public void ExibirVidaChefe(GameObject chefe)
    {
        painelVidaChefe.ExibirVidaChefe(chefe);
    }

    public void OcultarVidaChefe()
    {
        painelVidaChefe.pnlVidaChefe.SetActive(false);
    }
}
