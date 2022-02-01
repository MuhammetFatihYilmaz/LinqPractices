using System.Linq;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if(context.Students.Any())
                    return;

                context.Students.AddRange(
                    new Student
                    {
                        Name = "Ahmet",
                        Surname = "Mert",
                        ClassId = 1
                    },
                    new Student
                    {
                        Name = "Enis",
                        Surname = "Kaya",
                        ClassId = 1
                    },
                    new Student
                    {
                        Name = "Onur",
                        Surname = "Yıldız",
                        ClassId = 2
                    },
                    new Student
                    {
                        Name = "Leyla",
                        Surname = "Yıldız",
                        ClassId = 2
                    }

                );

                context.SaveChanges();
            }
        }
    }
}