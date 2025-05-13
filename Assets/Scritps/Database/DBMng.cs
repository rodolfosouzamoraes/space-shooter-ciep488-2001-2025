using UnityEngine;

public static class DBMng
{
    private const string PONTUACAO = "pontuacao";

    public static int BuscarPontuacaoSalva()
    {
        return PlayerPrefs.GetInt(PONTUACAO,0);
    }

    public static void SalvarPontuacao(int pontuacaoAtual)
    {
        //Obter a pontuacao salva anteriormente
        int pontuacaoAnterior = BuscarPontuacaoSalva();

        //verificar se a pontuacao atual é maior que a pontuacao anterior
        if(pontuacaoAtual > pontuacaoAnterior)
        {
            //Salvar a pontuacao atual na memoria
            PlayerPrefs.SetInt(PONTUACAO, pontuacaoAtual);
        }
    }
}
