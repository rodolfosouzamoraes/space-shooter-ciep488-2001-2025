using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    public TextMeshProUGUI txtMelhorPontuacao;
    public Image imgIconeVolume;
    public Sprite[] sptsVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Atualizar a pontução no texto
        txtMelhorPontuacao.text = $"{DBMng.BuscarPontuacaoSalva()}";
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
