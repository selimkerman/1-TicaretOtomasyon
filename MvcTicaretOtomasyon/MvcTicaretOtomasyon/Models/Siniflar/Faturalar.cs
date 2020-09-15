using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicaretOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int Faturaid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string FaturaSiraNo { get; set; }
    
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public  String Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }

        public decimal Toplam { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}