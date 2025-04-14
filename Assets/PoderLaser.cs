using UnityEngine;

public class PoderLaser : MonoBehaviour
{
    public float[] valoresDano; //Lista de danos
    public float valorDanoAtual; //Dano atual
    public Sprite[] poderes; //Imagens do laser
    public SpriteRenderer spriteLaser;//Manipular o sprite
    
    public void DefinirPoderLaser(int nivelPoder)
    {
        //Atualizar o dano do laser
        valorDanoAtual = valoresDano[nivelPoder];

        //Atualizar o sprite do laser
        spriteLaser.sprite = poderes[nivelPoder];
    }
}
