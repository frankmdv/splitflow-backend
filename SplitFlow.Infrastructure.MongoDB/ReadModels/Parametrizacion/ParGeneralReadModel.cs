﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion
{
    public class ParGeneralReadModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
