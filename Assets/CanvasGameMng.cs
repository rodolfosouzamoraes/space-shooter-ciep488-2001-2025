using TMPro;
using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public TextMeshProUGUI txtPontuacao; //Variável para manipular o texto da pontuação
    private float pontuacao;//Variavel para armazenar a pontuacao do jogo

    public GameObject[] vidasPlayer; //Os GameObjects da vida do jogador
    private int vidaJogador; //A quantidade de vida atual do jogador
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Zerar a pontuação quando o jogo começa
        pontuacao = 0;

        //Atualizar o texto da pontuação
        txtPontuacao.text = $"{pontuacao}";
    }

    public void IncrementarPontuacao(int pontuacao)
    {
        //Incrementar na variavel o ponto
        this.pontuacao += pontuacao;

        //Atualiza o texto da pontuação
        txtPontuacao.text = $"{this.pontuacao}";
    }
}
