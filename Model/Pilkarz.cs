using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze2.Model
{
    class Pilkarz
    {
        public int Id { set; get; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }

        public Pilkarz(int id, string imie, string nazwisko, uint wiek, uint waga)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public bool isTheSame(Pilkarz pilkarz)
        {
            if (pilkarz.Imie != Imie) return false;
            if (pilkarz.Nazwisko != Nazwisko) return false;
            if (pilkarz.Wiek != Wiek) return false;
            if (pilkarz.Waga != Waga) return false;
            return true;
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} lat: {Wiek} waga: {Waga} kg";
        }
    }
}
