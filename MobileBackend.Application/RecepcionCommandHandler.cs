using MediatR;

namespace MobileBackend.Application
{
    public record RecepcionCommand(string Id, string Nombre, int Numero) : IRequest<RecepcionResponse>;
    public record RecepcionResponse(bool Ok, string MensajeRespuesta);

    public class RecepcionCommandHandler : IRequestHandler<RecepcionCommand, RecepcionResponse>
    {
        public async Task<RecepcionResponse> Handle(RecepcionCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            if (!string.IsNullOrEmpty(request.Nombre))
                return new RecepcionResponse(true, $"Peticion exitosa por nombre:{request.Nombre}");
            else if (request.Numero > 0)
                return new RecepcionResponse(true, $"Peticion exitosa por numero:{request.Numero}");
            return new RecepcionResponse(false, $"Error en peticion");
        }
    }
}
