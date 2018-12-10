﻿using System;
using System.Collections.Generic;
using System.Text;
using App13.Modelos;
using System.Threading.Tasks;

namespace App13.Servicios
{
  public interface IServicioBaseDatos
    {
        Task<IEnumerable<Tarea>> ObtenerTareas();
        Task<Tarea> ObtenerTarea(int id);
        Task<bool> AgregarTarea(Tarea tarea);
        Task<bool> ActualizarTarea(Tarea tarea);
        Task<bool> EliminarTarea(int id);
        Task<IEnumerable<Tarea>> BuscarTareas(Func<Tarea, bool> condicion);

        Task<Emocion> ObtenerEmocion();
        Task<bool> AgregarEmocion(Emocion tarea);
        Task<bool> ActualizarEmocion(Emocion tarea);
        Task<bool> EliminarEmocion();
    }
}
