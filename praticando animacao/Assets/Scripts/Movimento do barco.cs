using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentodobarco : MonoBehaviour
{
    public float boatSpeed;         // Velocidade do barco
    public float angleDegrees;      // �ngulo de inclina��o em rela��o � margem
    public Vector2 currentVelocity; // Velocidade da correnteza
    public float stopY;             // Posi��o Y onde o barco deve parar

    private Vector2 boatVelocity;
    private bool isMoving = true;

    void Start()
    {
        // Aplica limita��es �s entradas
        boatSpeed = Mathf.Clamp(boatSpeed, 2.0f, 10.0f);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, 1.0f, 4.0f);
        angleDegrees = Mathf.Clamp(angleDegrees, 20.0f, 160.0f);

        // Converte o �ngulo de graus para radianos
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        // Calcula a dire��o inicial do barco com base no �ngulo de inclina��o
        float directionX = Mathf.Cos(angleRadians);
        float directionY = Mathf.Sin(angleRadians);

        // Define a velocidade inicial do barco com base na dire��o e na velocidade
        boatVelocity = new Vector2(directionX, directionY) * boatSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            // Calcula a velocidade total (barco + correnteza)
            Vector2 totalVelocity = boatVelocity + currentVelocity;

            // Atualiza a posi��o do barco
            transform.position += (Vector3)(totalVelocity * Time.deltaTime);

            // Verifica se o barco atingiu ou ultrapassou a posi��o Y desejada
            if (transform.position.y >= stopY)
            {
                isMoving = false;
                boatVelocity = Vector2.zero; // Para o movimento
            }
        }
    }

}

