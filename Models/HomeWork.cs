using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class HomeWork
    {
        [Key]
        public int Id { get; set; }                     // Иднтификатор записи
        public string Name { get; set; } = null!;       // Наименование предмета которому принадлежит запись
        public string DeadLine { get; set; } = null!;   // Установка срока выполенния
        public string? Assignement { get; set; }        // Задание которое будет предоставленно каждому ученику

        // Nav properties
        public Group Group { get; set; } = null!;   // Вызов внешнего ключа
    }
}
