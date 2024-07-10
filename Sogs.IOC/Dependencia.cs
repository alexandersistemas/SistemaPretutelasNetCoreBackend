using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sogs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sogs.DAL.Repositorios.Contrato;
using Sogs.DAL.Repositorios;
using Sogs.DAL.DBContext;

using Sogs.Utility;
using Sogs.BLL.Servicios.Contrato;
using Sogs.BLL.Servicios;

namespace Sogs.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SogsContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IPretutelaRepository, PretutelaRepository>();

            services.AddScoped<IPretutelaCompletaRepository, PretutelaCompletaRepository>();


            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPretutelaService, PretutelaService>();
            services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ISubCategoriaService, SubCategoriaService>();
            services.AddScoped<IDiscapacidadService, DiscapacidadService>();
            services.AddScoped<IEapbService, EapbService>();
            services.AddScoped<IEtniaService, EtniaService>();
            services.AddScoped<IGrupoPoblacionalService, GrupoPoblacionalService>();
            services.AddScoped<IIdentidadGeneroService, IdentidadGeneroService>();
            services.AddScoped<IMomentoCursoVidaService, MomentoCursoVidaService>();
            services.AddScoped<IParentescoService, ParentescoService>();
            services.AddScoped<IPoblacionPrioritariaService, PoblacionPrioritariaService>();
            services.AddScoped<IRegimenService, RegimenService>();
            services.AddScoped<IRespuestaService, RespuestaService>();
            services.AddScoped<ISexoService, SexoService>();
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<IPretutelaDocumentoService, PretutelaDocumentoService>();
            services.AddScoped<IPretutelaCompletaService, PretutelaCompletaService>();

        }
    }
}
