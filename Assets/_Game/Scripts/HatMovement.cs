using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        DragTouch();
    }

    private void DragTouch(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            //touchDeltaPosition - posicao do meu dedo na tela
            //speed - Velocidade
            //Time.deltaTime - normaliza a velocidade independente do FPS do celular
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
