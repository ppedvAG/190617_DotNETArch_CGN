using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PersonenVerwaltung.Model;

namespace PersonenVerwaltung.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IPersonenService service)
        {
            this.service = service;
            GetPersonen_Command = new RelayCommand(GetPersonen);
        }

        private void GetPersonen()
        {
            Personenliste = service.GetPersonen();
        }

        private readonly IPersonenService service;

        private List<Person> personenliste;
        public List<Person> Personenliste
        {
            get => personenliste;
            set => Set(ref personenliste, value);
        }
        public RelayCommand GetPersonen_Command { get; set; }
    }
}