using UnityEngine;

public class MoverNave : MonoBehaviour
{
    public float velocidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /*
        * Mover a nave para a posi��o do mouse 
        */

        //Pegar a posi��o do mouse
        Vector2 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Descobrir o limite m�ximo em X da nave
        float limiteX = Mathf.Clamp(posicaoMouse.x, -12, 12);

        //Descobrir o limite m�ximo em Y da nave
        float limiteY = Mathf.Clamp(posicaoMouse.y, -6.5f, 6.5f);

        //Definir a posi��o final da nave
        Vector2 posicaoNave = new Vector2(limiteX,limiteY);

        //definir a velocidade de movimentacao da nave at� o ponto
        float velocidadeMovimento = velocidade * Time.deltaTime;

        //Mover a nave para a posi��o
        transform.position = Vector3.MoveTowards(
            transform.position,
            posicaoNave,
            velocidadeMovimento
        );
    }
}
