namespace Mirra.Email.Function.Model
{
    public class EmailOutBoundRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
    }
}
