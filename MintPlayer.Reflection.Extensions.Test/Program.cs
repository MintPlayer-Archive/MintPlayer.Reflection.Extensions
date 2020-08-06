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

            var type = teacher.GetType();

            var baseTypeInterfaces = type.BaseType.GetInterfaces();
            var typeInterfaces = type.GetInterfaces();

            var interfaces = typeInterfaces.Except(baseTypeInterfaces);
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
