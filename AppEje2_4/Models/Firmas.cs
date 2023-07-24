using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppEje2_4.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Descripcion { get; set; }

        public Byte[] Imagen { get; set; }
    }
}
