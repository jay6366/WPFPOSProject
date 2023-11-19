using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Point_of_Sale.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        public string Name { get; set; }
        
        private int _Price;
        public int Price
        {
            get { return this._Price; }
            set
            {
                this._Price = value;
                this.OnPropertyChanged("Price");
            }
        }

        private Brush _Color = Brushes.White;


        public Brush Color
        {
            get { return this._Color; }
            set
            {
                this._Color = value;
                this.OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
                catch
                {

                }
            }
        }
    }
}
