using UnityEngine;

public class InstanciarObjeto : MonoBehaviour
{
    public GameObject objeto; //Objeto a ser instanciado
    public float tempoSurgimento; //Tempo para surgir cada objeto novo
    private float tempoEspera; //Tempo para permitir surgir cada objeto novo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar o tempo de espera para poder instanciar um objeto novo
        if (Time.time > tempoEspera) 
        { 
            //Atualizar o tempo de espera
            tempoEspera = Time.time + tempoSurgimento;

            //Definir a posição que o objeto vai surgir em X
            float posicaoX = Random.Range(-12, 12);

            //Instanciar o objeto
            GameObject novoObjeto = Instantiate(objeto);

            //Posicionar o objeto na coordenada X e Y
            novoObjeto.transform.position = new Vector3(posicaoX, 7.5f, 0);
        }
    }
}
