namespace Mirra.Email.Function.Templates
{
    public static class SavePreOrderInterest
    {
        public static string HtmlBody = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                    color: #333;
                }}
                h1 {{
                    color: white;
                    text-color: white;
                }}
                .content {{
                    padding: 20px;
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    background-color: #f9f9f9;
                    margin-bottom: 20px;
                }}
                .header {{
                    background-color: #007BFF;
                    color: white;
                    padding: 10px;
                    border-radius: 5px;
                }}
                .footer {{
                    font-size: 12px;
                    text-align: center;
                    color: #777;
                    margin-top: 20px;
                }}
                .details {{
                    margin-top: 20px;
                }}
                .details p {{
                    margin: 5px 0;
                }}
            </style>
        </head>
        <body>
            <div class='content'>
                <div class='header'>
                    <h1>Pre-Order Interest Request</h1>
                </div>
                
                <div class='details'>
                    <p><strong>Name:</strong> {{preOrderInterestRequest.Name}}</p>
                    <p><strong>Email:</strong> {{preOrderInterestRequest.Email}}</p>
                    <p><strong>Country:</strong> {{preOrderInterestRequest.Country}}</p>
                    <p><strong>Phone:</strong> {{preOrderInterestRequest.Phone}}</p>
                </div>
                
                <div class='footer'>
                    <p>Este é um e-mail automático. Não é necessário responder.</p>
                </div>
            </div>
        </body>
        </html>";
    }
}
