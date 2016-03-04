using System.Web;

namespace OnlineLearning.Models.Helper
{
    public class HQuestion
    {
        public int Id { get; set; }
        public HtmlString A_op { get; set; }
        public HtmlString B_op { get; set; }
        public HtmlString C_op { get; set; }
        public HtmlString D_op { get; set; }
        public string correct_op { get; set; }
        public string Image { get; set; }
        public int score { get; set; }
        public HtmlString Question1 { get; set; }
    }
}