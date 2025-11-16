namespace Mirra.Email.Function.Model.Request
{
    public class EmailInboundRequest
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
    }
}
