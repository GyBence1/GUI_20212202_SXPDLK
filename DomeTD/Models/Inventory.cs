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
    public class Inventory:INotifyPropertyChanged
    {
        private int dirt;

        public int Dirt
        {
            get { return dirt; }
            set
            {
                dirt = value;
                OnPropertyChanged("Dirt");
            }
        }
        private int metal;

        public int Metal
        {
            get { return metal; }
            set
            {
                metal = value;
                OnPropertyChanged("Metal");
            }
        }
        private int vibranium;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public int Vibranium
        {
            get { return vibranium; }
            set
            {
                vibranium = value;
                OnPropertyChanged("Vibranium");
            }
        }


    }
}
