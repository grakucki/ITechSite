using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public class ActionControlStatus : IDisposable
    {
        public enum ActionControlState  {Ok,Working,Warning,Error}

        private Button _Control { get; set; }
        private ActionControlState _State { get; set; }

        public ActionControlStatus(Button control)
        {
            _Control = control;
            _State = ActionControlState.Working;
        }

        public void ControlAction(Button button, ActionControlState state, string message="")
        {
            Color c = Color.Gray;
            int ImageIndex = 0;
            switch (state)
            {
                case ActionControlState.Ok: c = Color.Green;
                    ImageIndex = 1;
                    break;
                case ActionControlState.Working: c = Color.Orange;
                    break;
                case ActionControlState.Warning: c = Color.Yellow;
                    break;
                case ActionControlState.Error: c = Color.Red;
                    break;
                default: c = Color.Yellow;
                    break;
            }
            button.BackColor = c;
            button.ImageIndex = ImageIndex;
            button.Refresh();
        }

        public void SetState(ActionControlState state, string message)
        {
            _State = state;
            ControlAction(_Control, state, message);
            Application.DoEvents();
        }

        public void Dispose()
        {
            if (_State == ActionControlState.Working)
                SetState(ActionControlState.Error, "");
        }
    }
}
