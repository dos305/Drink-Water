using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Drink_Water {
    public class DataB {
        public int ID { get; set; }
        public string Username { get; set; }
        public int Weight { get; set; }
        public double WatAmount { get; set; }
        public DateTime Day { get; set; }
    }
}
