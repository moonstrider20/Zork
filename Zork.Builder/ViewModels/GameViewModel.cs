using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zork.Builder.ViewModels
{
    internal class GameViewModel //:INotifyPropertyChanged
    {
        //public BindingList<World> World { get; set; }
       // public event PropertyChangedEventHandler PropertyChanged;
       // public string mopeName { get; set; }

        public Game Game { get; set; }
    }
}
