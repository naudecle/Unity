using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 10f;
    public float SmoothTime = 0.1f;

    float velocity;
    public Transform cam;
    
    // Update is called once per frame
    void Update()
    {
        /*On veut bouger en utilisant WASD ou bien les Fleches du clavier
         * Les variables horizontal et vertical vont prendre les valeurs -1 et 1
         */

        /*La variable horizontal va prendre la valeur -1 si on presse A ou la fleche gauche
         * la valeur 1 si On presse D ou lla fleche de droite
         */
        float horizontal = Input.GetAxisRaw("Horizontal");

        /*La variable horizontal va prendre la valeur -1 si on presse W ou la fleche de haut
         * la valeur 1 si On presse S ou lla fleche d en bas
         */
        float vertical = Input.GetAxisRaw("Vertical");

        /*direction est une variable qui prend les valeurs des 3 axes(x,y,z)
         * x va prendre la valeur de la variable horizontal
         * z va prendre la valeur de la variable vertical
         * y va prendre la valeur 0 pour que le joueur reste au sol
         */
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if(direction.magnitude >= 0.1f)
        {
            /*Pour que le joueur pivote vers le chemin dans lequel il est entrain de mener
             * On va le pivoter sur l'axe y en utilisant la fonction Mathf.Atan2 qui retoune la valeur en radian dont Tan y/x
             */
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocity, SmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        
    }
}
