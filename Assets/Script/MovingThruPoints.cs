using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThruPoints : MonoBehaviour
{
    //Declarando as variaveis
    /*As primeiras variaveis declaradas são um array que guardara os waypoints
    e um index que indicara para qual waypoint o jogador deve ir no momento*/

    public GameObject[] waypoints;
    int currentWayPoint = 0;

    //As outras passam os atributos do jogador (velocidade, precisão e velocidade de rotação

    public float speed = 3.0f; 
    float accuracy = 3f;
    float rotSpeed = 0.5f;

    private void Start()
    {
        //Aqui o sistema procura pelos objetos com a tag waypoint

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

  
    void Update()
    {
        /*nesse primeiro if, conferimos se realmente há waypoints no array, caso não tenha ele retorna,
        impedindo que o codigo seja executado sem que haja para onde ir*/

        if (waypoints.Length == 0) return;

        /*Aqui a movimentação do cubo é definida, e ele é programado para se mover até os waypoints
        e para ir "olhando" para ele utilizando o rotation*/

        Vector3 lookAtGoal = new Vector3(waypoints[currentWayPoint].transform.position.x,
        this.transform.position.y, waypoints[currentWayPoint].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
             Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);

        /*Nesse if é ordenado que o caso o jogador esteja na posição de um dos waypoints, o waypoint atual
        seja atualizado e assim o cubo parta para o proximo waypoint da lista*/

        if (direction.magnitude < accuracy)
        {
            //incrementando waypoint atual 

            currentWayPoint++;

            //Caso não exista um proximo waypoint, o cubo devera retornar até o primeiro waypoint

            if(currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }

            
        }
        // atualiza a posição do cubo

        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
