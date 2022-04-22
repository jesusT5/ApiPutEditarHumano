using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPutEditarHumano.Modelo;

namespace ApiPutEditarHumano.Data
{
    public class ApiPutEditarHumanoContext : DbContext
    {
        public ApiPutEditarHumanoContext (DbContextOptions<ApiPutEditarHumanoContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPutEditarHumano.Modelo.Humano> Humano { get; set; }
    }
}
