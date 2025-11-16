using AutoMapper;

namespace Mirra.Email.Function.Mapper
{
    public class EmailRequestProfile : Profile
    {
        public EmailRequestProfile()
        {
            CreateMap<Model.Request.EmailInboundRequest, Model.EmailOutBoundRequest>();
        }
    }
}
