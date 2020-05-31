//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using Microsoft.Ajax.Utilities;

//namespace Vidly.Wep.App.Models
//{
//    public class VidlyContext :DbContext
//    {
       
//            public VidlyContext() : base(ConnectionString.Connection())
//            {

//            }



//            #region //Db Sets

//            public DbSet<Movie> Movies { get; set; }
//            public DbSet<Customer> Customers { get; set; }
//            public DbSet<MembershipType> MembershipTypes { get; set; }

            
//            #endregion

//            #region Fluent API

//            protected override void OnModelCreating(DbModelBuilder modelBuilder)
//            {
//                modelBuilder.Entity<Category>()
//                    .HasMany(d => d.Courses)
//                    .WithRequired(d => d.Category)
//                    .HasForeignKey(d => d.CategoryId);
//                modelBuilder.Entity<Trainer>()
//                    .HasMany(d => d.Courses)
//                    .WithRequired(d => d.Trainer)
//                    .HasForeignKey(d => d.TrainerId);
//                modelBuilder.Entity<Course>()
//                    .HasMany(d => d.Lessons)
//                    .WithRequired(d => d.Course)
//                    .HasForeignKey(d => d.CourseId);
//                modelBuilder.Entity<Course>()
//                    .HasMany(d => d.Members)
//                    .WithMany(d => d.Courses)
//                    .Map(cs =>
//                    {
//                        cs.MapLeftKey("RefCourseId");
//                        cs.MapRightKey("RefLessonId");
//                        cs.ToTable("CoursesLessons");
//                    });












//                base.OnModelCreating(modelBuilder);
//            }

//            #endregion


//        }
    
//}