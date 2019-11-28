using System;
using System.Collections.Generic;
using System.Text;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Domain.Models
{
    public class HomeIndexViewModel
    {
        public News[] News { get; set; }

        public bool IsSlvTeam { get; set; }
    }
}
