using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskTracker.Models
{
    public class ToDo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public OrderStatus Status { get; set; }


        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CompletedOn { get; set; }


    }

    public enum OrderStatus
    {
        ToDo,
        InProgress,
        Completed
    }

}