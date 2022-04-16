using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    //public class Bindable : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void OPC([CallerMemberName] string s = "")
    //    {
    //        PropertyChangedEventHandler handler =
    //            PropertyChanged;
    //        handler?.Invoke(this, new PropertyChangedEventArgs(s));
    //    }
    //}
    public class Inventory:ObservableObject
    {
        private int dirt;

        public int Dirt
        {
            get { return dirt; }
            set { SetProperty(ref dirt, value); }
        }
        private int metal;

        public int Metal
        {
            get { return metal; }
            set { SetProperty(ref metal, value); }
        }
        private int vibranium;

        public int Vibranium
        {
            get { return vibranium; }
            set { SetProperty(ref vibranium, value); }
        }


    }
}
