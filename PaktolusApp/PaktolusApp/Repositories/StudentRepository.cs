using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PaktolusApp.Interfaces;
using PaktolusApp.Models;
using PaktolusApp.ModelView;

namespace PaktolusApp.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        protected DbTestContext context;

        public StudentRepository(DbTestContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<StudentVM> GetStudentWithHobbies(int id)
        {
            var student = this.context.Students.Include(x => x.Hobbies).FirstAsync(x=> x.Id == id).Result;

            return new StudentVM
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                ZipCode = student.ZipCode,
                Hobbies = null,
                HobbiesId = student.Hobbies.Select(x=> x.Id).ToList()
            };
        }

        public async Task<IEnumerable<StudentVM>> GetStudentWithHobbiesNames()
        {
            return await this.context.Students.Include(x => x.Hobbies)
                                              .Select(y =>
                                              new StudentVM
                                              {
                                                  Id = y.Id,
                                                  Name = y.Name,
                                                  Email = y.Email,
                                                  Phone = y.Phone.Insert(3, "-").Insert(7, "-"),
                                                  ZipCode = y.ZipCode,
                                                  hobbiesName = String.Join(",",(y.Hobbies.Select(x=> x.Name)))
                                              }).ToListAsync();
        }

        public void RemoveHobbiesStudentById(int id)
        {

            var hobbies = this.context.Students.Include(s=> s.Hobbies).First(x=> x.Id == id).Hobbies.ToList();
            foreach (var item in hobbies)
            {
                 this.context.Students.Find(id).Hobbies.Remove(item);
            }

             this.context.SaveChanges();
        }

        public void AddHobbiesToStudent(Student student, List<int> hobbiesId)
        {
            if (hobbiesId != null)
            {
                foreach (var item in hobbiesId)
                {
                    student.Hobbies.Add(this.context.Hobbies.Find(item));
                }

                 this.context.SaveChanges();
            }
        }

    }
}

