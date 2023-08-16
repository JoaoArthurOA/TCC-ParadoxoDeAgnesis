using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentos : MonoBehaviour
{
    public float moveSpeed = 3;
    [HideInInspector] public Vector3 dir;
    float hzInput, vInput;
    CharacterController controller;
   
    [SerializeField]float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovimentoBase currentState;

    public Estadoidle Idle = new Estadoidle();
    public EstadoAnda Anda = new EstadoAnda();
    public EstadoCorre Corre = new EstadoCorre();
    public EstadoAgacha Agacha = new EstadoAgacha();
    
    public void SwitchState(MovimentoBase state)
    {
        currentState=state;
        currentState.EnterState(this);
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

   
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        currentState.UpdateState(this);
    }

    void GetDirectionAndMove()
    {
     hzInput = Input.GetAxis("Horizontal");
     vInput = Input.GetAxis("Vertical");

     dir = transform.forward * vInput + transform.right * hzInput;

     controller.Move(dir * moveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity ()
    {
      if(!IsGrounded()) velocity.y += gravity * Time.deltaTime;
      else if(velocity.y<0) velocity.y = -2;

      controller.Move(velocity * Time.deltaTime);
    }

    
}