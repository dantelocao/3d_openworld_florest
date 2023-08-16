using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed;
    public float rotationspeed;

    private CharacterController CharacterController;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float input_horizontal = Input.GetAxis("Horizontal");
        float input_vertical = Input.GetAxis("Vertical");

        Vector3 direcao_movimento = new Vector3(input_horizontal, 0, input_vertical);

        float magnitude = Mathf.Clamp01(direcao_movimento.magnitude) * speed;
        direcao_movimento.Normalize();

        CharacterController.SimpleMove(direcao_movimento * magnitude);

        if(direcao_movimento != Vector3.zero)
        {
            Quaternion rotacao = Quaternion.LookRotation(direcao_movimento, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacao, rotationspeed * Time.deltaTime);
        }

    }
}
