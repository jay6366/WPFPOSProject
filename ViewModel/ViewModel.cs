using Point_of_Sale.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Point_of_Sale.ViewModel
{
    public partial class ViewModel : ModelBase
    {
        public ICommand AddCommand => new RelayCommand<object>(Executed, CanExecuted);
        public ICommand DelCommand => new RelayCommand<object>(Executed, CanExecuted);
        public ICommand PlusCommand => new RelayCommand<object>(Plus_Executed, Plus_CanExecuted);
        public ICommand MinusCommand => new RelayCommand<object>(Minus_Executed, Minus_CanExecuted);

        public ObservableCollection<Model> Model { get; set; }
        public ObservableCollection<SalesModel> SalesModel { get; set; }
        private int _Total = 0;
        public int Total
        {
            get { return this._Total; }
            set
            {
                this._Total = value;
                this.OnPropertyChanged(nameof(Total));
            }
        }

        public ViewModel()
        {
            this.Model = new ObservableCollection<Model>();
            this.Model.Add(new Model { Name = "커피", Price = 2500, Color = new SolidColorBrush(Colors.Magenta) });
            this.Model.Add(new Model { Name = "아이스크림", Price = 1000, Color = new SolidColorBrush(Colors.YellowGreen) });
            this.Model.Add(new Model { Name = "김치김밥", Price = 2000, Color = new SolidColorBrush(Colors.Aqua) });
            this.Model.Add(new Model { Name = "초콜렛", Price = 2000, Color = new SolidColorBrush(Colors.White) });
            this.Model.Add(new Model { Name = "과자", Price = 800, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "코카콜라", Price = 1300, Color = new SolidColorBrush(Colors.Yellow) });
            this.Model.Add(new Model { Name = "피자", Price = 15000, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "생수", Price = 800, Color = new SolidColorBrush(Colors.Yellow) });
            this.Model.Add(new Model { Name = "라면", Price = 800, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "햇반", Price = 1500, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "우유", Price = 2500, Color = new SolidColorBrush(Colors.Magenta) });
            this.Model.Add(new Model { Name = "스팸", Price = 2500, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "짜파게티", Price = 800, Color = new SolidColorBrush(Colors.Green) });
            this.Model.Add(new Model { Name = "서울우유", Price = 2500, Color = new SolidColorBrush(Colors.Magenta) });
            this.Model.Add(new Model { Name = "하겐다즈", Price = 4070, Color = new SolidColorBrush(Colors.YellowGreen) });
            this.Model.Add(new Model { Name = "쿠게더", Price = 1800, Color = new SolidColorBrush(Colors.YellowGreen) });
            this.Model.Add(new Model { Name = "가나초콜렛", Price = 2000, Color = new SolidColorBrush(Colors.White) });
            this.Model.Add(new Model { Name = "허쉬초콜렛", Price = 2000, Color = new SolidColorBrush(Colors.White) });
            this.Model.Add(new Model { Name = "삼각김밥", Price = 2000, Color = new SolidColorBrush(Colors.Aqua) });
            this.Model.Add(new Model { Name = "사과", Price = 1000, Color = new SolidColorBrush(Colors.LimeGreen) });
            this.Model.Add(new Model { Name = "칫솔", Price = 800, Color = new SolidColorBrush(Colors.Violet) });
            this.Model.Add(new Model { Name = "도시락", Price = 2000, Color = new SolidColorBrush(Colors.Aqua) });
            this.Model.Add(new Model { Name = "매일우유", Price = 2500, Color = new SolidColorBrush(Colors.Magenta) });
            this.SalesModel = new ObservableCollection<SalesModel>();
        }

        private bool CanExecuted(object sender)
        {
            return true;
        }

        private void Executed(object sender)
        {
            if (sender is Model)
            {
                Model model = sender as Model;
                this.SalesModel.Add(new SalesModel { Name = model.Name, EA = 1, Price = model.Price, EaPrice = model.Price });
                this.Total = this.Calc();
            }
            else if (sender is SalesModel)
            {
                this.SalesModel.Remove(sender as SalesModel);

            }
        }

        private bool Plus_CanExecuted(object sender)
        {
            return true;
        }

        private void Plus_Executed(object sender)
        {
            SalesModel sales = sender as SalesModel;
            sales.EA++;
            sales.EaPrice = sales.EA * sales.Price;
            this.Total = this.Calc();
        }

        private bool Minus_CanExecuted(object sender)
        {
            bool ret = false;
            if (sender is SalesModel)
            {
                SalesModel sales = sender as SalesModel;
                if (sales.EA > 1)
                {
                    ret = true;
                }
            }
            return ret;
        }

        private void Minus_Executed(object sender)
        {
            SalesModel sales = sender as SalesModel;
            sales.EA--;
            sales.EaPrice = sales.EA * sales.Price;
            this.Total = this.Calc();
        }

        private int Calc()
        {
            return this.SalesModel.Sum(p => p.EA * p.Price);
        }


    }
}
