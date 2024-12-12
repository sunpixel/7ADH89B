using back.Models;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Additional
{
    // Intentional so that it doesn't rely on the Model.

    public class UserCredentials
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Group_Id { get; set; }
    }


    public class HomeWorkCredentilas
    {
        public string Name { get; set; } = null!;       // Наименование предмета которому принадлежит запись
        public string DeadLine { get; set; } = null!;   // Установка срока выполенния
        public string? Assignment { get; set; }         // Задание для выполнения
        public int Group_Id { get; set; }               // Востребованная переменная при создании
    }


    public class ScheduleCredentials
    {
        public string Day { get; set; } = null!;
        public string Time { get; set; } = null!;
        public string Subject_Name { get; set; } = null!;
        public int Group_Id { get; set; }
    }


    public class UserInfoCredentials
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public float? Grade { get; set; }
        public string University { get; set; } = null!;
        public string? Speciality { get; set; }
        public string User_Id { get; set; } = null!;
    }
}




