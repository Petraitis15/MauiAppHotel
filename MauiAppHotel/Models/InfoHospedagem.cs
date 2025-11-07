using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppHotel.Models
{
    public class InfoHospedagem
    {
        public int Adultos { get; set; }
        public int Criancas { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }
    }
}
