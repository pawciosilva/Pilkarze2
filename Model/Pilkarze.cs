using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pilkarze2.Model
{
    class Pilkarze
    {
        private static string plikArchiwizacji = "archiwum.txt";

        public List<Pilkarz> pilkarze { get; set; }

        public Pilkarze()
        {
            if (File.Exists(plikArchiwizacji))
            {
                var sPilkarze = File.ReadAllText(plikArchiwizacji);
                pilkarze = JsonConvert.DeserializeObject<List<Pilkarz>>(sPilkarze);
            }

            if (pilkarze == null)
            {
                pilkarze = new List<Pilkarz>();
            }
        }

        public void Edytuj(int id, string imie, string nazwisko, uint wiek, uint waga)
        {
            var index = pilkarze.FindIndex(x => x.Id == id);
            pilkarze[index].Imie = imie;
            pilkarze[index].Nazwisko = nazwisko;
            pilkarze[index].Wiek = wiek;
            pilkarze[index].Waga = waga;
            ZapiszDoPliku();
        }
        public Pilkarz Dodaj(string imie, string nazwisko, uint wiek, uint waga)
        {
            int id = pilkarze.Count() + 1;
            var pilkarz = new Pilkarz(id, imie, nazwisko, wiek, waga);
            pilkarze.Add(pilkarz);
            ZapiszDoPliku();
            return pilkarz;
        }

        public void Usun(int id)
        {
            var index = pilkarze.FindIndex(x => x.Id == id);
            pilkarze.RemoveAt(index);
            ZapiszDoPliku();
        }

        public void ZapiszDoPliku()
        {
            string json = JsonConvert.SerializeObject(pilkarze, Formatting.Indented);
            using (StreamWriter stream = new StreamWriter(plikArchiwizacji))
            {
                stream.Write(json);
                stream.Close();
            }
        }
    }
}
