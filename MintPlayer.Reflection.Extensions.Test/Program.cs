using System;
using System.Linq;

namespace MintPlayer.Reflection.Extensions.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher
            {
                FirstName = "John",
                LastName = "Roan",
                ClassName = "Math"
            };

            // Get type to investigate
            var type = teacher.GetType();
            var interfaces = type.GetInterfaces(true);

            foreach (var iface in interfaces)
                Console.WriteLine(iface.FullName);
        }
    }


    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface ITeacher : INeedsClassRoom
    {
        string ClassName { get; set; }
    }

    public class Teacher : Person, ITeacher
    {
        public string ClassName { get; set; }
        public string ClassRoomType { get; set; }
    }

    public interface INeedsClassRoom
    {
        string ClassRoomType { get; set; }
    }
}
