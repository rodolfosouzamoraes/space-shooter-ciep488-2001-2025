using UnityEngine;

public class MoverParaFrente : MonoBehaviour
{
    public float velocidade; //Velocidade do laser
    public float tempoDeExistencia; //Tempo de tela do laser
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o tempo de existencia do objeto
        Destroy(gameObject,tempoDeExistencia);
    }

    // Update is called once per frame
    void Update()
    {
        //Mover o objeto para uma direção, no caso para frente
        transform.Translate(Vector2.up * velocidade * Time.deltaTime); 
    }
}
