using Sogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sogs.DTO;
using Sogs.Utility;
using Sogs.DAL.DBContext;
using Sogs.DAL.Repositorios.Contrato;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;


namespace Sogs.DAL.Repositorios
{
    public class PretutelaCompletaRepository : GenericRepository<PretutelaPacienteRepresentadoDocDTO>, IPretutelaCompletaRepository
    {
        
        private readonly SogsContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly DocumentSettings _documentSettings;


        public PretutelaCompletaRepository(SogsContext dbcontext, IMapper mapper, EmailService emailService, IOptions<DocumentSettings> documentSettings) : base(dbcontext, mapper, emailService, documentSettings)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _documentSettings = documentSettings.Value;
        }

        public async Task<Pretutela> Registrar(Pretutela modelo)
        {
            Pretutela PretutelaGenerado = new Pretutela();

            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {

                    await _dbcontext.SaveChangesAsync();
                    PretutelaGenerado = modelo;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return PretutelaGenerado;

            }

        }


        public async Task<bool> GuardarPretutelaCompleta(PretutelaPacienteRepresentadoDocDTO model)
        {
            using (var transaction = await _dbcontext.Database.BeginTransactionAsync())
            {
                try
                {

                    

                    // Guardar el formulario PACIENTE
                    var form2Entity = _mapper.Map<Paciente>(model.Form2);                    
                    _dbcontext.Pacientes.Add(form2Entity);
                    await _dbcontext.SaveChangesAsync();

                    // Guardar el formulario PRETUTELA
                    var form3Entity = _mapper.Map<Pretutela>(model.Form3);
                    form3Entity.IdPaciente = form2Entity.IdPaciente; // Asignar la relación
                    _dbcontext.Pretutelas.Add(form3Entity);
                    await _dbcontext.SaveChangesAsync();

                    // Guardar los items del vector en la tabla DOCUMENTO Y PRETUTELADOCUMENTO
                    Documento? form4Entity = null;
                    PretutelaDocumento? form5Entity = null;
                    foreach (var VectorArchivosDTO in model.VectorItems)
                    {
                        form4Entity = _mapper.Map<Documento>(model.Form4);
                        form4Entity.NombreDocumento = VectorArchivosDTO.NombreItem;
                        form4Entity.RutaDocumento = "UploadedFiles/";
                        _dbcontext.Documentos.Add(form4Entity);

                        await _dbcontext.SaveChangesAsync();

                        form5Entity = _mapper.Map<PretutelaDocumento>(model.Form5);
                        form5Entity.IdPretutela = form3Entity.IdPretutela; // Asignar la relación
                        form5Entity.IdDocumento = form4Entity.IdDocumento; // Asignar la relación                        
                        _dbcontext.PretutelaDocumentos.Add(form5Entity);

                        await _dbcontext.SaveChangesAsync();

                    }
        
                    // Confirmar la transacción
                    await transaction.CommitAsync();

                    // Mapear las entidades a DTOs y retornar
                    //var result = new PretutelaPacienteRepresentadoDocDTO
                    //{
                    //    Form1 = form1Entity != null ? _mapper.Map<RepresentadoDTO>(form1Entity) : null,
                    //    Form2 = _mapper.Map<PacienteDTO>(form2Entity),
                    //    Form3 = _mapper.Map<PretutelaDTO>(form3Entity),
                    //    Form4 = form4Entity != null ? _mapper.Map<DocumentoDTO>(form4Entity) : null,
                    //    Form5 = form5Entity != null ? _mapper.Map<PretutelaDocumentoDTO>(form4Entity) : null
                    //};

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }




    }
}
