
namespace StackOverflow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Question
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Topic is required.")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Problem is required.")]
        public string Problem { get; set; }
    
        public virtual User User { get; set; }
    }
}
