using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    public interface IInputService
    {
        event EventHandler<string> InputRecieved;
    }
}