namespace ThomasGregChallenge.API.Exceptions
{
    /// <summary>
    ///  Classe que representa uma exce��o lan�ada para o client como resposta.
    ///</summary>
    public class ExceptionPayload
    {
        public int Codigo { get; set; }

        public string? Mensagem { get; set; }

        public IEnumerable<ValidationFailure>? Erros { get; set; }

        /// <summary>
        /// M�todo para criar um novo ExceptionPayload de uma exce��o de neg�cio.
        ///          
        /// As exce��es de neg�cio, que s�o providas no NDD.Configuracoes.Portal.Domain
        /// s�o identificadas pelos c�digos no enum ErrorCodes. 
        /// 
        /// Assim, esse m�todo monta o ExceptionPayload, que ser� o c�digo retornado o cliente, 
        /// com base na exce��o lan�ada.
        /// 
        /// </summary>
        /// <param name="exception">� a exce��o lan�ada</param>
        /// <param name="errorCode">C�digo HTTP de erro</param>
        /// <param name="failures">Lista de problemas de valida��o</param>
        /// <returns>ExceptionPayload contendo o c�digo do erro e a mensagem da da exce��o que foi lan�ada </returns>
        public static ExceptionPayload New<T>(T exception, int errorCode, IEnumerable<ValidationFailure>? failures = null) where T : Exception
        {
            return new ExceptionPayload
            {
                Codigo = errorCode,
                Mensagem = exception.Message,
                Erros = failures,
            };
        }
    }
}
