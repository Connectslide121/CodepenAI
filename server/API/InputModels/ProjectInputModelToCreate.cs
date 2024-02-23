namespace API.InputModels
{
    public class ProjectInputModelToCreate
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HtmlCode { get; set; }
        public string CssCode { get; set; }
        public string JsCode { get; set; }
        public int TotalTokens { get; set; }
        public float TotalMoney { get; set; }

    }
}
