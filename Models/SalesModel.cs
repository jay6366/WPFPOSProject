using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale.Models
{
    public class SalesModel : ModelBase
    {
        private int _EA;
        public int EA
        {
            get { return this._EA; }
            set
            {
                this._EA = value;
                OnPropertyChanged("EA");
            }
        }

        private int _EaPrice;
        public int EaPrice
        {
            get { return this._EaPrice; }
            set
            {
                this._EaPrice = value;
                OnPropertyChanged("EaPrice");
            }
        }
        public SalesModel()
        {

        }

    }
}
