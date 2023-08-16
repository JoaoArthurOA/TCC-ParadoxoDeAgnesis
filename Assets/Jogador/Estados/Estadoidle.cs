using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadoidle : MovimentoBase
{
  public override void EnterState (Movimentos movement)
  {

  }

  public override void UpdateState (Movimentos movement)
  {
    if(movement.dir.magnitude>0.1f)
    {
        if(Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Corre);
        else movement.SwitchState(movement.Anda);
    }
    if(Input.GetKeyDown(KeyCode.C)) movement.SwitchState(movement.Agacha);
  }
}
