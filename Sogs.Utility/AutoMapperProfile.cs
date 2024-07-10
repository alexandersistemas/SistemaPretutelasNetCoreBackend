using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Sogs.DTO;
using Sogs.Model;

namespace Sogs.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          
            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
               .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)
                );


            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                    destino.IdRolNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado == 1 ? true : false)
                //opt => opt.MapFrom(origen => Convert.ToString(origen.precio.Value, new CultureInfo("es.PE")))
                );

            #endregion Usuario
            
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Discapacidad, DiscapacidadDTO>().ReverseMap();
            CreateMap<Documento, DocumentoDTO>().ReverseMap();
            CreateMap<Eapb, EapbDTO>().ReverseMap();
            CreateMap<Etnia, EtniaDTO>().ReverseMap();
            CreateMap<GrupoPoblacional, GrupoPoblacionalDTO>().ReverseMap();
            CreateMap<IdentidadGenero, IdentidadGeneroDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<MomentoCursoVida, MomentoCursoVidaDTO>().ReverseMap();
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Parentesco, ParentescoDTO>().ReverseMap();
            CreateMap<PoblacionPrioritaria, PoblacionPrioritariaDTO>().ReverseMap();
            CreateMap<Pretutela, PretutelaDTO>().ReverseMap();
            CreateMap<Regimen, RegimenDTO>();
            CreateMap<Respuesta, RespuestaDTO>();
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<Sexo, SexoDTO>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaDTO>().ReverseMap();            
            CreateMap<TipoDocumento, TipoDocumentoDTO>().ReverseMap();
            CreateMap<Usuario, SesionDTO>().ReverseMap();
            CreateMap<PretutelaDocumento, PretutelaDocumentoDTO >().ReverseMap();

            CreateMap<Usuario, SesionDTO>()
           .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.IdRolNavigation.NombreRol));

            CreateMap<Pretutela, PretutelaDTO>()
            .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.IdPacienteNavigation.NumeroDocumento))
            .ForMember(dest => dest.NombreEapb, opt => opt.MapFrom(src => src.IdEapbNavigation.NombreEapb))
            .ForMember(dest => dest.NombreCategoria, opt => opt.MapFrom(src => src.IdCategoriaNavigation.NombreCategoria))
            .ForMember(dest => dest.NombreSubCategoria, opt => opt.MapFrom(src => src.IdSubCategoriaNavigation.NombreSubCategoria))
            .ForMember(dest => dest.NombreRespuesta, opt => opt.MapFrom(src => src.IdRespuestaNavigation.NombreRespuesta));            

            CreateMap<Paciente, PacienteDTO>()
            .ForMember(dest => dest.NombreTipoDocumento, opt => opt.MapFrom(src => src.IdTipoDocumentoNavigation.NombreTipoDocumento))
            .ForMember(dest => dest.NombreSexo, opt => opt.MapFrom(src => src.IdSexoNavigation.NombreSexo))
            .ForMember(dest => dest.NombreGrupoPob, opt => opt.MapFrom(src => src.IdGrupoPobNavigation.NombreGrupoPob))
            .ForMember(dest => dest.NombreEtnia, opt => opt.MapFrom(src => src.IdEtniaNavigation.NombreEtnia))
            .ForMember(dest => dest.NombrePoblacionPrioritaria, opt => opt.MapFrom(src => src.IdPoblacionPrioritariaNavigation.NombrePoblacionPrioritaria))
            .ForMember(dest => dest.NombreParentesco, opt => opt.MapFrom(src => src.IdParentescoNavigation.NombreParentesco))
            .ForMember(dest => dest.NombreRegimen, opt => opt.MapFrom(src => src.IdRegimenNavigation.NombreRegimen))
            .ForMember(dest => dest.NombreIdentidadGenero, opt => opt.MapFrom(src => src.IdIdentidadGeneroNavigation.NombreIdentidadGenero))
            .ForMember(dest => dest.NombreDiscapacidad, opt => opt.MapFrom(src => src.IdDiscapacidadNavigation.NombreDiscapacidad))
            .ForMember(dest => dest.NombreMomentoCursoVida, opt => opt.MapFrom(src => src.IdMomentoCursoVidaNavigation.NombreMomentoCursoVida))
            .ForMember(dest => dest.NombreTipoDocumentoRepresentado, opt => opt.MapFrom(src => src.IdTipoDocumentoRepresentadoNavigation.NombreTipoDocumento));
            


        }
    }
}
