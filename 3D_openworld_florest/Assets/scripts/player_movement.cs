using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input_horizontal = Input.GetAxis("Horizontal");
        float input_vertical = Input.GetAxis("Vertical");

        Vector3 direcao_movimento = new Vector3(input_horizontal, 0, input_vertical);
        direcao_movimento.Normalize();

        transform.Translate(direcao_movimento * speed * Time.deltaTime);

    }
}
