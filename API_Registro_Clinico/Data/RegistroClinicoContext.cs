using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace API_Registro_Clinico.Data
{
    public class RegistroClinicoContext : DbContext
    {
        public RegistroClinicoContext(DbContextOptions<RegistroClinicoContext> options) : base(options)
        {

        }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<DetallesExamen> DetallesExamen { get; set; }
        public DbSet<DetallesExamenesResultados> DetallesExamenesResultados { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Enfermera> Enfermera { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<HistorialMedico> HistorialMedico { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<OrientacionMedica> OrientacionMedica { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PreConsulta> PreConsulta { get; set; }
        public DbSet<PrescripcionMedica> PrescripcionMedica { get; set; }
        public DbSet<ProximaCita> ProximaCita { get; set; }


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Doctor
            modelBuilder.Entity<Doctor>()
                .ToTable("Doctor")
                .HasKey(d => d.DoctorID);
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Especialidad)
                .WithMany()
                .HasForeignKey(d => d.EspecialidadID);

            // Configuración de Paciente
            modelBuilder.Entity<Paciente>()
                .ToTable("Paciente")
                .HasKey(p => p.PacienteID);

            // Configuración de Consulta
            modelBuilder.Entity<Consulta>()
                .ToTable("Consulta")
                .HasKey(c => c.ConsultaID);
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorID);
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteID);

            // Configuración de Examen
            modelBuilder.Entity<Examen>()
                .ToTable("Examen")
                .HasKey(e => e.ExamenID);
            modelBuilder.Entity<Examen>()
                .HasOne(e => e.Consulta)
                .WithMany()
                .HasForeignKey(e => e.ConsultaID);

            // Configuración de DetallesExamen
            modelBuilder.Entity<DetallesExamen>()
                .ToTable("DetallesExamen")
                .HasKey(de => de.DetallesExamenID);
            modelBuilder.Entity<DetallesExamen>()
                .HasOne(de => de.Examen)
                .WithMany()
                .HasForeignKey(de => de.ExamenID);

            // Configuración de DetallesExamenesResultados
            modelBuilder.Entity<DetallesExamenesResultados>()
                .ToTable("DetallesExamenesResultados")
                .HasKey(der => der.DetallesExamenesResultadosID);
            modelBuilder.Entity<DetallesExamenesResultados>()
                .HasOne(der => der.DetallesExamen)
                .WithMany()
                .HasForeignKey(der => der.DetallesExamenID);

            // Configuración de ProximaCita
            modelBuilder.Entity<ProximaCita>()
                .ToTable("ProximaCita")
                .HasKey(pc => pc.ProximaCitaID);
            modelBuilder.Entity<ProximaCita>()
                .HasOne(pc => pc.Doctor)
                .WithMany()
                .HasForeignKey(pc => pc.DoctorID);
            modelBuilder.Entity<ProximaCita>()
                .HasOne(pc => pc.Paciente)
                .WithMany()
                .HasForeignKey(pc => pc.PacienteID);

            // Configuración de PrescripcionMedica
            modelBuilder.Entity<PrescripcionMedica>()
                .ToTable("PrescripcionMedica")
                .HasKey(pm => pm.PrescripcionMedicaID);
            modelBuilder.Entity<PrescripcionMedica>()
                .HasOne(pm => pm.OrientacionMedica)
                .WithMany()
                .HasForeignKey(pm => pm.OrientacionMedicaID);

            // Configuración de OrientacionMedica
            modelBuilder.Entity<OrientacionMedica>()
                .ToTable("OrientacionMedica")
                .HasKey(om => om.OrientacionMedicaID);
            modelBuilder.Entity<OrientacionMedica>()
                .HasOne(om => om.Consulta)
                .WithMany()
                .HasForeignKey(om => om.ConsultaID);
            modelBuilder.Entity<OrientacionMedica>()
                .HasOne(om => om.Medicamento)
                .WithMany()
                .HasForeignKey(om => om.MedicamentoID);

            // Configuración de Enfermera
            modelBuilder.Entity<Enfermera>()
                .ToTable("Enfermera")
                .HasKey(e => e.EnfermeraID);

            // Configuración de PreConsulta
            modelBuilder.Entity<PreConsulta>()
                .ToTable("PreConsulta")
                .HasKey(pc => pc.PreConsultaID);
            modelBuilder.Entity<PreConsulta>()
                .HasOne(pc => pc.Enfermera)
                .WithMany()
                .HasForeignKey(pc => pc.EnfermeraID);
            modelBuilder.Entity<PreConsulta>()
                .HasOne(pc => pc.Paciente)
                .WithMany()
                .HasForeignKey(pc => pc.PacienteID);

            // Configuración de HistorialMedico
            modelBuilder.Entity<HistorialMedico>()
                .ToTable("HistorialMedico")
                .HasKey(hm => hm.HistorialMedicoID);
            modelBuilder.Entity<HistorialMedico>()
                .HasOne(hm => hm.Paciente)
                .WithMany()
                .HasForeignKey(hm => hm.PacienteID);

            // Configuración de Especialidad
            modelBuilder.Entity<Especialidad>()
                .ToTable("Especialidad")
                .HasKey(e => e.EspecialidadID);

            // Configuración de Medicamento
            modelBuilder.Entity<Medicamento>()
                .ToTable("Medicamento")
                .HasKey(m => m.MedicamentoID);
        }*/
    }
}
    