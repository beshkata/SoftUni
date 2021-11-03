﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string LogoUrl { get; set; }

        [MaxLength(4)]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public Color SecondaryKitColor { get; set; }

        public Town Town { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
