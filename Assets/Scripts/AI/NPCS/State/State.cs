using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
        public State nextState;
        public GameObject myGameObject;
        public Animator animator;
        public enum STATE 
        {
                ReceptionMoveToNode,ReceptionInteract
        };

        public enum STAGE
        {
                Enter, Update, Exit, None
        };

        public State( GameObject myGo)
        {
                this.myGameObject = myGo;
                this.animator = myGo.GetComponent<Animator>();

        }

        public STAGE stage;
        public STATE state;

        public virtual void Enter()
        {
                this.stage = STAGE.Update;    
        }

        public virtual void Update()
        {
                this.stage = STAGE.Update;
        }

        public virtual void Exit()
        {
                this.stage = STAGE.Exit;
        }

        public virtual void None()
        {
                return;
        }

        public State Process()
        {
                if (stage == STAGE.Exit)
                {
                        Exit();
                        return nextState;
                }

                if (stage == STAGE.Enter)
                        Enter();

                else if (stage == STAGE.Update)
                        Update();
                else if (stage == STAGE.None)
                        None();
               
                return this;
        }


}
