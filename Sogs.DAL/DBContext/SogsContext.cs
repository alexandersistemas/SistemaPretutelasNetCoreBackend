using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sogs.Model;

namespace Sogs.DAL.DBContext;

public partial class SogsContext : DbContext
{
    public SogsContext()
    {
    }

    public SogsContext(DbContextOptions<SogsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Discapacidad> Discapacidads { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Eapb> Eapbs { get; set; }

    public virtual DbSet<Etnia> Etnia { get; set; }

    public virtual DbSet<GrupoPoblacional> GrupoPoblacionals { get; set; }

    public virtual DbSet<IdentidadGenero> IdentidadGeneros { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<MomentoCursoVida> MomentoCursoVida { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<PoblacionPrioritaria> PoblacionPrioritaria { get; set; }

    public virtual DbSet<Pretutela> Pretutelas { get; set; }

    public virtual DbSet<PretutelaDocumento> PretutelaDocumentos { get; set; }

    public virtual DbSet<Regimen> Regimen { get; set; }

    public virtual DbSet<Respuesta> Respuesta { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<SubCategoria> SubCategoria { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C0C6DC16C");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Discapacidad>(entity =>
        {
            entity.HasKey(e => e.IdDiscapacidad);

            entity.ToTable("Discapacidad");

            entity.Property(e => e.IdDiscapacidad).HasColumnName("idDiscapacidad");
            entity.Property(e => e.NombreDiscapacidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PK_DIM_DOCUMENTO");

            entity.ToTable("Documento");

            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RutaDocumento)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Eapb>(entity =>
        {
            entity.HasKey(e => e.IdEapb).HasName("PK_DIM_EAPB");

            entity.ToTable("EAPB");

            entity.Property(e => e.IdEapb).HasColumnName("idEAPB");
            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreEapb)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NombreEAPB");
        });

        modelBuilder.Entity<Etnia>(entity =>
        {
            entity.HasKey(e => e.IdEtnia);

            entity.Property(e => e.IdEtnia).HasColumnName("idEtnia");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreEtnia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GrupoPoblacional>(entity =>
        {
            entity.HasKey(e => e.IdGrupoPob);

            entity.ToTable("GrupoPoblacional");

            entity.Property(e => e.IdGrupoPob).HasColumnName("idGrupoPob");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreGrupoPob)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IdentidadGenero>(entity =>
        {
            entity.HasKey(e => e.IdIdentidadGenero);

            entity.ToTable("IdentidadGenero");

            entity.Property(e => e.IdIdentidadGenero).HasColumnName("idIdentidadGenero");
            entity.Property(e => e.NombreIdentidadGenero)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF4836A1EB70D");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A463E77D9B");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__17F790F9");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__18EBB532");
        });

        modelBuilder.Entity<MomentoCursoVida>(entity =>
        {
            entity.HasKey(e => e.IdMomentoCursoVida);

            entity.Property(e => e.IdMomentoCursoVida).HasColumnName("idMomentoCursoVida");
            entity.Property(e => e.NombreMomentoCursoVida)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK_DIM_PACIENTE");

            entity.ToTable("Paciente");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.ApellidosRepresentado)
                .HasMaxLength(160)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.IdDiscapacidad).HasColumnName("idDiscapacidad");
            entity.Property(e => e.IdEtnia).HasColumnName("idEtnia");
            entity.Property(e => e.IdGrupoPob).HasColumnName("idGrupoPob");
            entity.Property(e => e.IdIdentidadGenero).HasColumnName("idIdentidadGenero");
            entity.Property(e => e.IdMomentoCursoVida).HasColumnName("idMomentoCursoVida");
            entity.Property(e => e.IdParentesco).HasColumnName("idParentesco");
            entity.Property(e => e.IdPoblacionPrioritaria).HasColumnName("idPoblacionPrioritaria");
            entity.Property(e => e.IdRegimen).HasColumnName("idRegimen");
            entity.Property(e => e.IdSexo).HasColumnName("idSexo");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.IdTipoDocumentoRepresentado).HasColumnName("idTipoDocumentoRepresentado");
            entity.Property(e => e.NombresRepresentado)
                .HasMaxLength(160)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumentoRepresentado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtroParentesco)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.OtroRegimen)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDiscapacidadNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDiscapacidad)
                .HasConstraintName("FK__Paciente__idDisc__09A971A2");

            entity.HasOne(d => d.IdEtniaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdEtnia)
                .HasConstraintName("FK__Paciente__idEtni__5DCAEF64");

            entity.HasOne(d => d.IdGrupoPobNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdGrupoPob)
                .HasConstraintName("FK__Paciente__idGrup__5CD6CB2B");

            entity.HasOne(d => d.IdIdentidadGeneroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdIdentidadGenero)
                .HasConstraintName("FK__Paciente__idIden__06CD04F7");

            entity.HasOne(d => d.IdMomentoCursoVidaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdMomentoCursoVida)
                .HasConstraintName("FK__Paciente__idMome__0D7A0286");

            entity.HasOne(d => d.IdParentescoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdParentesco)
                .HasConstraintName("FK__Paciente__idPare__619B8048");

            entity.HasOne(d => d.IdPoblacionPrioritariaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdPoblacionPrioritaria)
                .HasConstraintName("FK__Paciente__idPobl__5FB337D6");

            entity.HasOne(d => d.IdRegimenNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdRegimen)
                .HasConstraintName("FK__Paciente__idRegi__628FA481");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdSexo)
                .HasConstraintName("FK__Paciente__idSexo__02FC7413");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.PacienteIdTipoDocumentoNavigations)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__idTipo__5BE2A6F2");

            entity.HasOne(d => d.IdTipoDocumentoRepresentadoNavigation).WithMany(p => p.PacienteIdTipoDocumentoRepresentadoNavigations)
                .HasForeignKey(d => d.IdTipoDocumentoRepresentado)
                .HasConstraintName("FK__Paciente__idTipo__74794A92");
        });

        modelBuilder.Entity<Parentesco>(entity =>
        {
            entity.HasKey(e => e.IdParentesco).HasName("PK_PARENTESCO");

            entity.ToTable("Parentesco");

            entity.Property(e => e.IdParentesco).HasColumnName("idParentesco");
            entity.Property(e => e.NombreParentesco)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PoblacionPrioritaria>(entity =>
        {
            entity.HasKey(e => e.IdPoblacionPrioritaria).HasName("PK_DIM_POBPRI");

            entity.Property(e => e.IdPoblacionPrioritaria).HasColumnName("idPoblacionPrioritaria");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombrePoblacionPrioritaria)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pretutela>(entity =>
        {
            entity.HasKey(e => e.IdPretutela).HasName("PK_DIM_PRETUTELA");

            entity.ToTable("Pretutela");

            entity.HasIndex(e => new { e.NumeroRadicado, e.FechaRecepcion }, "indexPretutela");

            entity.Property(e => e.IdPretutela).HasColumnName("idPretutela");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRecepcion).HasColumnType("datetime");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdEapb).HasColumnName("idEAPB");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdRespuesta).HasColumnName("idRespuesta");
            entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroRadicado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pretutela__idCat__693CA210");

            entity.HasOne(d => d.IdEapbNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdEapb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pretutela__idEAP__6B24EA82");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Pretutela__idPac__6A30C649");

            entity.HasOne(d => d.IdRespuestaNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdRespuesta)
                .HasConstraintName("fk");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdSubCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pretutela__idSub__123EB7A3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pretutelas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Pretutela__idUsu__73852659");
        });

        modelBuilder.Entity<PretutelaDocumento>(entity =>
        {
            entity.HasKey(e => e.IdPretutelaDocumento).HasName("PK__Pretutel__34B248D3B3215B31");

            entity.ToTable("PretutelaDocumento");

            entity.Property(e => e.IdPretutelaDocumento).HasColumnName("idPretutelaDocumento");
            entity.Property(e => e.IdDocumento).HasColumnName("idDocumento");
            entity.Property(e => e.IdPretutela).HasColumnName("idPretutela");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.PretutelaDocumentos)
                .HasForeignKey(d => d.IdDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentoPretutela_Documento");

            entity.HasOne(d => d.IdPretutelaNavigation).WithMany(p => p.PretutelaDocumentos)
                .HasForeignKey(d => d.IdPretutela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentoPretutela_Pretutela");
        });

        modelBuilder.Entity<Regimen>(entity =>
        {
            entity.HasKey(e => e.IdRegimen).HasName("PK_DIM_REGIMEN");

            entity.Property(e => e.IdRegimen).HasColumnName("idRegimen");
            entity.Property(e => e.NombreRegimen)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => e.IdRespuesta).HasName("PK_DIM_RESPUESTA");

            entity.Property(e => e.IdRespuesta).HasColumnName("idRespuesta");
            entity.Property(e => e.NombreRespuesta)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7603A7AD88");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo);

            entity.ToTable("Sexo");

            entity.Property(e => e.IdSexo).HasColumnName("idSexo");
            entity.Property(e => e.NombreSexo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.IdSubCategoria).HasName("PK__SubCateg__F89A24CC73AC232A");

            entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.NombreSubCategoria)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__idCat__10566F31");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__TipoDocu__61FDF9F59F730CCB");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreTipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6B0D5045E");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__idRol__3B75D760");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__idTipoD__57DD0BE4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
