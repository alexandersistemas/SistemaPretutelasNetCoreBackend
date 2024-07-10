using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sogs.DAL.Repositorios.Contrato;
using Sogs.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Sogs.DTO;
using Sogs.Model;
using AutoMapper;
using Sogs.Utility;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;







namespace Sogs.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly SogsContext _dbContext;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly DocumentSettings _documentSettings;


        public GenericRepository(SogsContext dbContext, IMapper mapper, EmailService emailService, IOptions<DocumentSettings> documentSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _emailService = emailService;
            _documentSettings = documentSettings.Value;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo = filtro == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
                return queryModelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GuardarPretutelaCompleta(PretutelaPacienteRepresentadoDocDTO model)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var basePath = _documentSettings.BasePath;
                    string NombreSubCategoria = "";

                    // Guardar el formulario PACIENTE
                    var form2Entity = _mapper.Map<Paciente>(model.Form2);
                    _dbContext.Pacientes.Add(form2Entity);
                    await _dbContext.SaveChangesAsync();

                    // Guardar el formulario PRETUTELA
                    var form3Entity = _mapper.Map<Pretutela>(model.Form3);
                    form3Entity.IdPaciente = form2Entity.IdPaciente; // Asignar la relación
                    _dbContext.Pretutelas.Add(form3Entity);
                    await _dbContext.SaveChangesAsync();


                    // Cargar la subcategoría relacionada para obtener el nombre
                    form3Entity = await _dbContext.Pretutelas
                        .Include(p => p.IdSubCategoriaNavigation) // Incluir la navegación a la subcategoría
                        .FirstOrDefaultAsync(p => p.IdPretutela == form3Entity.IdPretutela);

                    if (form3Entity?.IdSubCategoriaNavigation != null)
                    {
                        NombreSubCategoria = form3Entity.IdSubCategoriaNavigation.NombreSubCategoria;
                    }


                    // Guardar los items del vector en la tabla DOCUMENTO Y PRETUTELADOCUMENTO
                    Documento? form4Entity = null;
                    PretutelaDocumento? form5Entity = null;                    
                    var adjuntos = new List<string>();



                    foreach (var VectorArchivosDTO in model.VectorItems)
                    {
                        form4Entity = _mapper.Map<Documento>(model.Form4);
                        form4Entity.NombreDocumento = VectorArchivosDTO.NombreItem;
                        form4Entity.RutaDocumento = "UploadedFiles/";
                        _dbContext.Documentos.Add(form4Entity);

                        //Aqui se arma la ruta completa para adjuntar los documentos al correo electronico a enviar
                        adjuntos.Add(form4Entity.RutaDocumento + VectorArchivosDTO.NombreItem);

                        await _dbContext.SaveChangesAsync();

                        form5Entity = _mapper.Map<PretutelaDocumento>(model.Form5);
                        form5Entity.IdPretutela = form3Entity.IdPretutela; // Asignar la relación
                        form5Entity.IdDocumento = form4Entity.IdDocumento; // Asignar la relación                        
                        _dbContext.PretutelaDocumentos.Add(form5Entity);

                        await _dbContext.SaveChangesAsync();

                    }


                    // Obtener el correo electrónico relacionado con el IdEapb
                    var eapb = await _dbContext.Eapbs.FindAsync(form3Entity.IdEapb);
                    if (eapb != null && !string.IsNullOrEmpty(eapb.Correo))
                    {
                        // Llamar al método para enviar el correo electrónico
                        await _emailService.EnviarCorreoAsync(eapb.Correo, NombreSubCategoria + " # Radicado:" + form3Entity.NumeroRadicado, form3Entity.Descripcion, adjuntos);


                    }


                    // Confirmar la transacción
                    await transaction.CommitAsync();





                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Error al guardar la pretutela completa: " + ex.Message, ex);
                }
            }
        }



    }


}
