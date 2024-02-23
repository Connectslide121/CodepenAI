using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Project
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HtmlCode { get; set; }
        public string CssCode { get; set; }
        public string JsCode { get; set; }
        public DateTime CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] public DateTime UpdatedAt { get; set; }
        public int TotalTokens { get; set; }
        public float TotalMoney { get; set; }
    }
}
