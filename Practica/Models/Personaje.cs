using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Practica.Models
{
    
    public class Personaje
    {
        [PrimaryKey, AutoIncrement]
        public int Id   { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }

        public string Species { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }


    }
}
