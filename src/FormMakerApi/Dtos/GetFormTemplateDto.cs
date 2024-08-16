using FormMaker.Entities;
using FormMakerApi.Entities;
using Shared.Dtos;

namespace FormMakerApi.Dtos
{
    public class GetFormTemplateDto
    {
        public string Title { get;  set; }

        public List<FormComponent>? Components { get;  set; }
        public ApplicationUserDto Creator { get;  set; }
        public int Version { get;  set; }
    }
}
