using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameMng : MonoBehaviour
{
    private EscudoPlayer escudoPlayer;//Variavel com a informação do escudo do jogador

    [Header("Config Painel Topo")]
    public TextMeshProUGUI txtPontuacao; //Variável para manipular o texto da pontuação
    private int pontuacao;//Variavel para armazenar a pontuacao do jogo
    public GameObject[] vidasPlayer; //Os GameObjects da vida do jogador
    private int vidaJogador; //A quantidade de vida atual do jogador
    public TextMeshProUGUI txtNivelJogo;
    public int nivelJogo;//Define o nivel dos inimigos no jogo
    public float tempoDificuldade;//tempo para aumentar o nivel do jogo
    public GameObject pnlTopo;

    [Header("Config Painel Game Over")]
    public GameObject pnlGameOver;
    public TextMeshProUGUI txtPontuacaoAtual;
    public TextMeshProUGUI txtMelhorPontuacao;

    [Header("Config Painel Vida Chefe")]
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
        OcultarVidaChefe();
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
            //Exibir a tela de game over
            ExibirTelaFimDeJogo();
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

    public void ExibirTelaFimDeJogo()
    {
        //Desabilitar todas as vidas
        foreach (var vida in vidasPlayer) {
            vida?.SetActive(false);
        }        

        vidaJogador = 0;

        //Matar o jogador
        FindFirstObjectByType<DanoPlayer>().DestruirPlayer();

        //Ocultar o painel topo
        pnlTopo.SetActive(false);

        //Exibir painel Game Over
        pnlGameOver.SetActive(true);

        //Configurar dados no painel game over
        txtPontuacaoAtual.text = $"{pontuacao}";

        //Salvar dados
        DBMng.SalvarPontuacao(pontuacao);

        //Atualizar o texto de melhor pontuacao
        txtMelhorPontuacao.text = $"{DBMng.BuscarPontuacaoSalva()}";
    }

    public void ReiniciarJogo()
    {
        //Reiniciar a cena atual com base no código da cena
        int codigoCena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(codigoCena);
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
