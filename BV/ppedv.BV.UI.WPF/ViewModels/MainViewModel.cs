using ppedv.BV.Data.EF;
using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using ppedv.BV.Logic;
using ppedv.BV.UI.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.BV.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Produktiv;Trusted_Connection=true;AttachDbFilename=C:\temp\BV.mdf";

        public MainViewModel()
        {
            // Kontrollfreak-Antipattern
            core = new Core(new EFRepository(new EFContext(connectionString)));
            GetBookStoreWithHighestValue_Command = new RelayCommand(GetBookStore);
        }

        private void GetBookStore(object obj)
        {
            BookStoreWithHighestValue = core.GetBookStoreWithHighestInventoryValue();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BookStoreWithHighestValue"));
        }

        private Core core;
        public event PropertyChangedEventHandler PropertyChanged;


        public BookStore BookStoreWithHighestValue { get; set; }
        public ICommand GetBookStoreWithHighestValue_Command { get; set; }
    }
}
