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
        public string temp { get; set; }
        public string tensao { get; set; }
        public string corrente { get; set; }

        public Arduino()
        {
            
        }
        public Arduino(List<string> data)
        {            
            this.temp = data[0];
            this.tensao = data[1];
            this.corrente = data[2];
        }
    }
}
