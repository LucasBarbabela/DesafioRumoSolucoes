using Api.Enum;

namespace Api.Utility.Exception
{
    public class ApiException : System.Exception
    {
        public StatusCodeEnum StatusCode;
        public long Code;

        public ApiException() : base()
        { }

        public ApiException(string message) : base(message)
        {
            this.StatusCode = StatusCodeEnum.InternalServerError;
        }

        public ApiException(StatusCodeEnum statusCode, MsgException MSG, string Campo = "", string Mensagem = "")
        : base(((int)MSG).ToString() + " - " + MSGD.GetDescription(MSG) + ((Campo == "") ? "" : " - Campo: " + Campo) + ((Mensagem == "") ? "" : " - " + Mensagem))
        {
            this.StatusCode = statusCode;
            this.Code = (int)MSG;
        }
    }
}
