using UnityEngine;

public class InstanciarObjeto : MonoBehaviour
{
    public GameObject objeto; //Objeto a ser instanciado
    public float tempoSurgimento; //Tempo para surgir cada objeto novo
    protected float tempoEspera; //Tempo para permitir surgir cada objeto novo
    public bool eInimigo; //Define se o objeto é um inimigo
    protected CanvasGameMng canvasGameMng;//Referencia do canvas game mng
    public bool aguardarPrimeiro;//Define se o objeto deve aguardar primeiro antes de ser instanciado

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referenciar o CanvasGameMng
        canvasGameMng = FindFirstObjectByType<CanvasGameMng>();

        //Verificar se o objeto deve esperar o tempo inicial de surgimento
        if(aguardarPrimeiro == true)
        {
            //atualizar o tempo de espera
            tempoEspera = Time.time + tempoSurgimento;
        }
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

            //Verificar se o objeto é um inimigo
            if (eInimigo == true) {
                //Definir o nivel do inimigo
                int nivelJogo = canvasGameMng.nivelJogo;
                novoObjeto.GetComponent<DanoAoInimigo>().DefinirNivelInimigo(nivelJogo);
            }

            //Posicionar o objeto na coordenada X e Y
            novoObjeto.transform.position = new Vector3(posicaoX, 7.5f, 0);
        }
    }
}
