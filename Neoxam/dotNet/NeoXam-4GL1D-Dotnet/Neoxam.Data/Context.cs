namespace Neoxam.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<bonus> bonus { get; set; }
        public virtual DbSet<candidate_response> candidate_response { get; set; }
        public virtual DbSet<candidate_sheet> candidate_sheet { get; set; }
        public virtual DbSet<candidate_test> candidate_test { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<complaint> complaints { get; set; }
        public virtual DbSet<degree_project> degree_project { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<extra_hours> extra_hours { get; set; }
        public virtual DbSet<goal> goals { get; set; }
        public virtual DbSet<high_school> high_school { get; set; }
        public virtual DbSet<holiday> holidays { get; set; }
        public virtual DbSet<interview> interviews { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<justificatory> justificatories { get; set; }
        public virtual DbSet<meeting> meetings { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<month_employee> month_employee { get; set; }
        public virtual DbSet<non_attendance> non_attendance { get; set; }
        public virtual DbSet<pay> pays { get; set; }
        public virtual DbSet<penality> penalities { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<question_response> question_response { get; set; }
        public virtual DbSet<reclamation> reclamations { get; set; }
        public virtual DbSet<risk> risks { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<test> tests { get; set; }
        public virtual DbSet<traineeship> traineeships { get; set; }
        public virtual DbSet<training> trainings { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<videoconference> videoconferences { get; set; }
        public virtual DbSet<meeting_user> meeting_user { get; set; }
        public virtual DbSet<mission_user> mission_user { get; set; }
        public virtual DbSet<risk_user> risk_user { get; set; }
        public virtual DbSet<test_user> test_user { get; set; }
        public virtual DbSet<training_user> training_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<candidate_response>()
                .Property(e => e.Response)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.CV_PDF_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.CV_TXT_Path)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.diploma)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.linkedin_account_link)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.mail_address1)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.mail_address2)
                .IsUnicode(false);

            modelBuilder.Entity<candidate_sheet>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<complaint>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<complaint>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<degree_project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<degree_project>()
                .Property(e => e.Topic)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<goal>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<high_school>()
                .Property(e => e.Name1)
                .IsUnicode(false);

            modelBuilder.Entity<high_school>()
                .Property(e => e.Name2)
                .IsUnicode(false);

            modelBuilder.Entity<high_school>()
                .Property(e => e.Name3)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<justificatory>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<meeting>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<meeting>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<penality>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<question_response>()
                .Property(e => e.Content)
                .IsUnicode(false);

         

            modelBuilder.Entity<reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);


          



            modelBuilder.Entity<reclamation>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<risk>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<risk>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.Domain)
                .IsUnicode(false);

            modelBuilder.Entity<traineeship>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.Former)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.Place)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.mail_address)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.path_image)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.CV_PDF_Path)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.CV_TXT_Path)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Linkedin_account_link)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.High_school)
                .IsUnicode(false);
        }
    }
}
