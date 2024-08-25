using Bpms.Domain.Proto;
using FormMaker.Dtos;
using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace FormMaker.Grpc
{
    public class FormService : FormServiceGrpc.FormServiceGrpcBase
    {
        private readonly IRepository<FormData> _formDataRepository;

        public FormService(IRepository<FormData> formDataRepository)
        {
            _formDataRepository = formDataRepository;
        }
        [AllowAnonymous]
        public async Task<ServerResponse> CreateFormData(GrpcRequest request, ServerCallContext context)
        {
            var formDataDto = new CreateFormDataDto
            {
                AssigneeId = request.AssigneeId,
                FormId = request.FormId
            };

            var formData = new FormData(formDataDto);
            var result = _formDataRepository.AddAsync(formData);
            return new ServerResponse { FormDataId = result.Id };
        }
    }
}
