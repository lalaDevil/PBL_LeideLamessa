using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentodobarco : MonoBehaviour
{
    public float boatSpeed;         // Velocidade do barco
    public float angleDegrees;      // Ângulo de inclinação em relação à margem
    public Vector2 currentVelocity; // Velocidade da correnteza
    public float stopY;             // Posição Y onde o barco deve parar

    private Vector2 boatVelocity;
    private bool isMoving = true;

    void Start()
    {
        // Aplica limitações às entradas
        boatSpeed = Mathf.Clamp(boatSpeed, 2.0f, 10.0f);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, 1.0f, 4.0f);
        angleDegrees = Mathf.Clamp(angleDegrees, 20.0f, 160.0f);

        // Converte o ângulo de graus para radianos
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        // Calcula a direção inicial do barco com base no ângulo de inclinação
        float directionX = Mathf.Cos(angleRadians);
        float directionY = Mathf.Sin(angleRadians);

        // Define a velocidade inicial do barco com base na direção e na velocidade
        boatVelocity = new Vector2(directionX, directionY) * boatSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            // Calcula a velocidade total (barco + correnteza)
            Vector2 totalVelocity = boatVelocity + currentVelocity;

            // Atualiza a posição do barco
            transform.position += (Vector3)(totalVelocity * Time.deltaTime);

            // Verifica se o barco atingiu ou ultrapassou a posição Y desejada
            if (transform.position.y >= stopY)
            {
                isMoving = false;
                boatVelocity = Vector2.zero; // Para o movimento
            }
        }
    }

}

