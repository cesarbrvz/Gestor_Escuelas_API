using System;
using System.Collections.Generic;

namespace GestorEscuelas.Models;

public partial class EscuelasDeMusica
{
    public int IdEscuela { get; set; }

    public string CodigoEscuela { get; set; } = null!;

    public string? NombreEscuela { get; set; }

    public string? DescripcionEscuela { get; set; }

}
