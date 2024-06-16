using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class HomeWork
    {
        [Key]
        public int Id { get; set; }                 // Иднтификатор предмета
        public string Name { get; set; } = null!;   // Наименование предмета которому принадлежит запись
        public DateOnly DeadLine { get; set; }      // Установка срока выполенния
        public string? Assignement { get; set; }    // Задание которое будет предоставленно каждому ученику

        // Nav properties
        public Group Group { get; set; } = null!;   // Вызов внешнего ключа
    }
}
