using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class InstanciarInimigosZigZag : InstanciarObjeto
{
    public int maxObjetos; //Definir o máximo de inimigos que irão ser instanciados
    public float tempoInstanciamento; //Tempo de instanciamente de um objeto para outro
    private int totalInstanciados = 0; //Armazenar o total que foram instanciados


    // Update is called once per frame
    void Update()
    {
        //A lógica de instanciar inimigos de tempo em tempo
        if(Time.time > tempoEspera)
        {
            //Atualiza tempo de espera
            tempoEspera = Time.time + tempoSurgimento;

            //Ativa Coroutine
            StartCoroutine(InstanciarObjetosSimultaneos());
        }
    }

    IEnumerator InstanciarObjetosSimultaneos()
    {
        //Definir aleatóriamente uma posição de intanciamento do objeto
        float posicaoX = Random.Range(-12, 12);

        //zerar o total de inimigos instanciados
        totalInstanciados = 0;

        //Repetição do instanciamento dos objetos
        do
        {
            //aguardar um tempo para poder instanciar
            yield return new WaitForSeconds(tempoInstanciamento);

            //Instanciar o objeto
            GameObject novoObjeto = Instantiate(objeto);

            //Posicionar o objeto na posição sorteada
            novoObjeto.transform.position = new Vector3(posicaoX, 7.5f, 0);

            //Somar o total de objetos instanciados
            totalInstanciados++;
        } while (totalInstanciados <= maxObjetos);
    }
}
