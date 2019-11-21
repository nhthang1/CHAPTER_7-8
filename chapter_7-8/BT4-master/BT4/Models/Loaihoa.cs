using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BT4.Models
{
    public class Loaihoa
    {
        [PrimaryKey, AutoIncrement]
        public int Maloai { get; set; }
        public string Tenloai { get; set; }
    }
}
