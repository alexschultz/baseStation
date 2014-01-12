using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input; // to provide shorthand to clear up ambiguities
using Input = Microsoft.Xna.Framework.Input;
using System.Threading;

namespace controller
{
    public class Controller
    {
        //To keep track of the current and previous state of the gamepad
        /// <summary>
        /// The current state of the controller
        /// </summary>
        private Input.GamePadState gamePadState;
        
        public Controller()
        {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        }

        public string GetControllerState()
        {
            StringBuilder state = new StringBuilder("c");
            gamePadState = GamePad.GetState(PlayerIndex.One);
            state.Append(((int)((gamePadState.ThumbSticks.Left.Y) * 1000)).ToString());
            state.Append("|");
            state.Append(((int)((gamePadState.ThumbSticks.Right.X + 1) * 1000 / 2)).ToString());
            state.Append("|");
            state.Append(((int)((gamePadState.ThumbSticks.Right.Y + 1) * 1000 / 2)).ToString());
            state.Append("|");
            state.Append(((int)(gamePadState.Triggers.Left * 100)).ToString());
            state.Append("|");
            state.Append(((int)(gamePadState.Triggers.Right * 100)).ToString());
            state.Append("|");
            state.Append(gamePadState.Buttons.A == Input.ButtonState.Pressed ? "A" : "0");
            state.Append("|");
            state.Append(gamePadState.Buttons.B == Input.ButtonState.Pressed ? "B" : "0");
            state.Append("|");
            state.Append(gamePadState.Buttons.X == Input.ButtonState.Pressed ? "X" : "0");
            state.Append("|");
            state.Append(gamePadState.Buttons.Y == Input.ButtonState.Pressed ? "Y" : "0");
            return state.ToString();
            
        }

        // This method is called by the timer delegate. 
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            
        }
    }
}
