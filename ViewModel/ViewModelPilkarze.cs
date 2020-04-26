using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pilkarze2.Model;
using Pilkarze2.ViewModel.BaseClass;

namespace Pilkarze2.ViewModel
{
    class ViewModelPilkarze : ViewModelBase
    {
        public Model.Pilkarze pilkarzeModel { get; set; }
        private List<Pilkarz> pilkarze = new List<Pilkarz>();

        public List<Pilkarz> Pilkarze
        {
            get { return pilkarze; }

            set
            {
                onPropertyChanged(nameof(pilkarze));
                pilkarze = new List<Pilkarz>(pilkarzeModel.pilkarze);
                onPropertyChanged(nameof(pilkarze));
            }
        }

        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public uint waga { get; set; }
        public uint wiek { get; set; }
        public Pilkarz wybrany { get; set; }
        public ViewModelPilkarze()
        {
            pilkarzeModel = new Model.Pilkarze();
            pilkarze = new List<Pilkarz>(pilkarzeModel.pilkarze);
            onPropertyChanged(nameof(pilkarze));
        }

        private ICommand _dodaj = null;
        public ICommand Dodaj
        {
            get
            {
                if (_dodaj == null)
                {
                    _dodaj = new RelayCommand
                    (arg =>
                    {
                        if (wiek == 0) wiek = 15;
                        if (waga == 0) waga = 50;
                        pilkarzeModel.Dodaj(imie, nazwisko, wiek, waga);
                        pilkarze = new List<Pilkarz>(pilkarzeModel.pilkarze);
                        onPropertyChanged(nameof(pilkarze));
                        wybrany = null;
                        onPropertyChanged(nameof(imie));
                        onPropertyChanged(nameof(nazwisko));
                        onPropertyChanged(nameof(wiek));
                        onPropertyChanged(nameof(waga));
                        imie = null;
                        nazwisko = null;
                        wiek = 0;
                        waga = 0;
                        onPropertyChanged(nameof(imie));
                        onPropertyChanged(nameof(nazwisko));
                        onPropertyChanged(nameof(wiek));
                        onPropertyChanged(nameof(waga));
                    },
                    arg => imie != null && nazwisko != null);
                }
                return _dodaj;
            }
        }

        private ICommand _edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (_edytuj == null)
                {
                    _edytuj = new RelayCommand
                    (arg =>
                    {
                        if (wiek == 0) wiek = 15;
                        if (waga == 0) waga = 50;
                        pilkarzeModel.Edytuj(wybrany.Id, imie, nazwisko, wiek, waga);
                        pilkarze = new List<Pilkarz>(pilkarzeModel.pilkarze);
                        onPropertyChanged(nameof(pilkarze));
                        wybrany = null;
                        imie = null;
                        nazwisko = null;
                        wiek = 0;
                        waga = 0;
                        onPropertyChanged(nameof(imie));
                        onPropertyChanged(nameof(nazwisko));
                        onPropertyChanged(nameof(wiek));
                        onPropertyChanged(nameof(waga));
                    },
                    arg => wybrany != null);
                }

                return _edytuj;
            }
        }

        private ICommand _usun = null;

        public ICommand Usun
        {
            get
            {
                if (_usun == null)
                {
                    _usun = new RelayCommand
                    (arg =>
                    {
                        pilkarzeModel.Usun(wybrany.Id);
                        pilkarze = new List<Pilkarz>(pilkarzeModel.pilkarze);
                        onPropertyChanged(nameof(pilkarze));
                        wybrany = null;
                        onPropertyChanged(nameof(wybrany));
                        imie = null;
                        nazwisko = null;
                        wiek = 0;
                        waga = 0;
                        onPropertyChanged(nameof(imie));
                        onPropertyChanged(nameof(nazwisko));
                        onPropertyChanged(nameof(wiek));
                        onPropertyChanged(nameof(waga));
                    },
                    arg => wybrany != null);
                }
                return _usun;
            }
        }

        private ICommand _wybierz = null;
        public ICommand Wybierz
        {
            get
            {
                if (_wybierz == null)
                {
                    _wybierz = new RelayCommand
                    (arg =>
                    {
                        if (wybrany != null)
                        {
                            imie = wybrany.Imie;
                            nazwisko = wybrany.Nazwisko;
                            waga = wybrany.Waga;
                            wiek = wybrany.Wiek;
                            onPropertyChanged(nameof(imie));
                            onPropertyChanged(nameof(nazwisko));
                            onPropertyChanged(nameof(wiek));
                            onPropertyChanged(nameof(waga));
                        }
                    },
                    arg => true);
                }
                return _wybierz;
            }
        }
    }
}
