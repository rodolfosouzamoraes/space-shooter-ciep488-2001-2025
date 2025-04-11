using UnityEngine;

public class MoverZigZag : MonoBehaviour
{
    public float velocidade;
    public float tempoVirada;//Tempo que ele aguardará para ir na outra direção
    public float tempoDeExistencia;
    private float direcao;//Direção para onde o objeto vai
    private float tempoDeEspera;//Tempo para esperar a troca de direção
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Contar tempo de espera inicial
        tempoDeEspera = Time.time + tempoVirada;

        //Definir a direção inicial
        direcao = 1;

        //Destruir o objeto depois de um tempo
        Destroy(gameObject, tempoDeExistencia);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar o tempo atual para poder mudar a direção do objeto
        if (Time.time > tempoDeEspera) {
            //Atualizar o tempo de espera
            tempoDeEspera = Time.time + tempoVirada;

            //Inverter a direção
            direcao *= -1;
        }

        //Definir a direção da movimentacao
        Vector3 direcaoFinal = new Vector3(1 * direcao, 2f, 0);

        //Movimentar o objeto na direção
        transform.Translate(direcaoFinal * velocidade * Time.deltaTime);
    }
}
