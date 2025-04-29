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

    private void DestruirChefe()
    {
        //Acessar o script do chefe para poder destruílo
        //...

        //Desativar o painel do chefe
        pnlVidaChefe.SetActive (false);

        //Definir que o chefe não está mais ativo
        chefeAtivo = false;
    }

    public void DecrementarVidaChefe(float dano)
    {
        //Decrementar a vida do chefe
        vidaAtualChefe -= dano;

        //Verificar se a vida acabou
        if (vidaAtualChefe <= 0)
        {
            //Destruir o chefe
            DestruirChefe();
        }

        //Atualizar o slider e o texto do chefe
        sldVidaChefe.value = vidaAtualChefe;
        txtVidaChefe.text = $"{vidaAtualChefe}";
    }
}
