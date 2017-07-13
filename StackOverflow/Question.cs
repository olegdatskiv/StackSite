

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

        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    
        public virtual User User { get; set; }
    }
}
