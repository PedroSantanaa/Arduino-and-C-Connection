using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_DB.modules
{
    public class Arduino
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string Tensao { get; set; }
        //public string Corrente { get; set; }
        public string Porta { get; set; }
        public string NivelDaAgua { get; set; }
        public string TemperaturaAnormais { get; set; }
        public string TensaoAnormais { get; set; }
        public string NivelDaAguaBaixo { get; set; }
        //public string CorrenteAnormais { get; set; }

        public Arduino()
        {

        }
        public Arduino(List<string> data)
        {
            double temp = double.Parse(data[0]);
            double voltage = double.Parse(data[1]);
            double water = double.Parse(data[3]);
            if (data[2] == "1")
            {
                Porta = "Porta Fechada";
            }
            else
            {
                Porta = "Porta Aberta";
            }
            if (temp >= 26)
            {
                this.TemperaturaAnormais = data[0];
                this.Temperatura = "Temperatura acima do desejado";
            }
            else
            {
                this.Temperatura = data[0];
                this.TemperaturaAnormais = "Tudo dentro da normalidade";
            }

            if (voltage >= 15)
            {
                this.TensaoAnormais = data[1];
                this.Tensao = "Tensao acima do desejado";
            }
            else
            {
                this.Tensao = data[1];
                this.TensaoAnormais = "Tudo dentro da normalidade";
            }
            if (water / 100 <= 4)
            {
                this.NivelDaAguaBaixo = data[3];
                this.NivelDaAgua = "Nivel da agua abaixo do desejado";
            }
            else
            {
                this.NivelDaAgua = data[3];
                this.NivelDaAguaBaixo = "Tudo dentro da normalidade";
            }

            //if (double.Parse(data[2]) >= 0.6)
            //{
            //    this.CorrenteAnormais = data[2];
            //    this.Corrente = "Corrente acima do desejado";
            //}
            //else
            //{
            //    this.Corrente = data[2];
            //    this.CorrenteAnormais = "Tudo dentro da normalidade";
            //}
        }
    }
}
