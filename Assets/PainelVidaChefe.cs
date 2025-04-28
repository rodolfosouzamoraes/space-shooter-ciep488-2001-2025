using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PainelVidaChefe : MonoBehaviour
{
    public GameObject pnlVidaChefe;
    public Slider sldVidaChefe;
    public TextMeshProUGUI txtVidaChefe;
    public float vidaMaximaChefe;
    private float vidaAtualChefe;
    private GameObject chefe;
    private bool chefeAtivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar o slider para comportar a vida do chefe
        sldVidaChefe.maxValue = vidaMaximaChefe;

        //Definir que o slider comece preenchido
        sldVidaChefe.value = vidaMaximaChefe;

        //Definir a vida atual do chefe
        vidaAtualChefe = vidaMaximaChefe;

        //Atualizar o texto com a vida atual do chefe
        txtVidaChefe.text = $"{vidaAtualChefe}";

        //Desativar o painel quando o jogo começar
        pnlVidaChefe.SetActive(false);
    }

    /// <summary>
    /// Método para exibir a tela de vida a cada novo chefe
    /// </summary>
    public void ExibirVidaChefe(GameObject novoChefe)
    {
        //Referencia o chefe novo com a variavel chefe
        chefe = novoChefe;

        //Resetar a vida atual do chefe
        vidaAtualChefe = vidaMaximaChefe;

        //Resetar o value do slider da vida do chefe
        sldVidaChefe.value = vidaAtualChefe;

        //Resetar o texto da vida do chefe
        txtVidaChefe.text = $"{vidaAtualChefe}";

        //Exibir a tela do painel de vida do chefe
        pnlVidaChefe.SetActive(true);

        //Dizer que o chefe está ativo
        chefeAtivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
