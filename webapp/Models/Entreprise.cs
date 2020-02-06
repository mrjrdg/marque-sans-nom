using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Models
{
    public class Entreprise
    {
        public int Id { get; set; }
        public string EntrepriseName { get; set; }
        public string EntrepriseAdresseHQ { get; set; }
        public string EntreprisePhone { get; set; }
    }
}