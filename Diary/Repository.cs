using Diary.Models.Domains;
using Diary.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Diary.Models.Converters;
using Diary.Models;
using System.Runtime.Remoting.Contexts;

namespace Diary
{
    public class Repository
    {
        public List<Group> GetGroups()
        {
            using (var contex = new ApplicationDbContext())
            {
                return contex.Groups.ToList();
            }
        }

        public List<StudentWrapper> GetStudents(int groupId)
        {
            using (var context = new ApplicationDbContext())
            {
                var students = context
                    .Students
                    .Include(x => x.Group)
                    .Include(x => x.Ratings)
                    .AsQueryable();

                if(groupId != 0) 
                {
                    students = students.Where(x => x.GroupId == groupId);
                }

                return students
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .ToList();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var studentToDelete = context.Students.Find(id);
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateStudentProperties(student, context);

                var studentRatings = GetStudentsRatings(student, context);

                UpdateRate(student, ratings, context, studentRatings, Subject.Math);
                UpdateRate(student, ratings, context, studentRatings, Subject.Technology);
                UpdateRate(student, ratings, context, studentRatings, Subject.Physics);
                UpdateRate(student, ratings, context, studentRatings, Subject.PolishLang);
                UpdateRate(student, ratings, context, studentRatings, Subject.ForeignLang);

                context.SaveChanges();
            }
        }

        private void UpdateStudentProperties(Student student, ApplicationDbContext context)
        {
            var studentToUpdate = context.Students.Find(student.Id);

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.GroupId = student.GroupId;
            studentToUpdate.Comments = student.Comments;
            studentToUpdate.Activities = student.Activities;
        }

        private static List<Rating> GetStudentsRatings(Student student, ApplicationDbContext context)
        {
            return context.Ratings.Where(x => x.StudentId == student.Id).ToList();
        }
        private static void UpdateRate(Student student, List<Rating> newRatings, ApplicationDbContext context, List<Rating> studentsRatings, Subject subject)
        {
            var subjectRatings = studentsRatings
                    .Where(x => x.SubjectId == (int)subject)
                    .Select(x => x.Rate).ToList();

            var newSubjectRatings = newRatings
                .Where(x => x.SubjectId == (int)subject)
                .Select(x => x.Rate).ToList();

            // TODO: instrukcja Except nie działa poprawnie.
            // Przykładowo, gdy mamy w ocenach: 5, 5, 5 i checmy je wszystkie usunąć, usunięta zostanie tylko jedna piątka
            var subjectRatingsToDelete = subjectRatings.Except(newSubjectRatings).ToList();
            var subjectRatingsToAdd = newSubjectRatings.Except(subjectRatings).ToList();

            subjectRatingsToDelete.ForEach(x =>
            {
                var ratingToDelete = context.Ratings.First(y => y.Rate == x && y.StudentId == student.Id && y.SubjectId == (int)subject);
                context.Ratings.Remove(ratingToDelete);
            });

            subjectRatingsToAdd.ForEach(x =>
            {
                var ratingToAdd = new Rating
                {
                    Rate = x,
                    StudentId = student.Id,
                    SubjectId = (int)subject
                };
                context.Ratings.Add(ratingToAdd);
            });
        }

        public void AddStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDao();

            using (var context = new ApplicationDbContext())
            {
                var dbStudent = context.Students.Add(student);

                ratings.ForEach(x =>
                {
                    x.StudentId = dbStudent.Id;
                    context.Ratings.Add(x);
                });

                context.SaveChanges();
            }
        }
    }
}
