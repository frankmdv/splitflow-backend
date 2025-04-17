﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Parametrizacion
{
    public class CreateParGeneralCommand : IRequest<long>
    {
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
