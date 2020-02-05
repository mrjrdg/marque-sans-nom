using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using webapp.Models;
using webapp.Data;

namespace webapp.Models
{
    public class Entreprise
    {
        public int Id { get; set; }
        public string EnterpriseName { get; set; }
        public string EnterPriseAdresseHQ { get; set; }
        public string EnterPrisePhone { get; set; }


    }
}