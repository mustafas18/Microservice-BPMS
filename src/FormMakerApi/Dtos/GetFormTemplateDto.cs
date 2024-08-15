using eShop.Identity.API.Models;
using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class GetFormTemplateDto
    {
        public string Title { get;  set; }

        public List<FormComponent> Components { get;  set; }
        public ApplicationUser Creator { get;  set; }
        public int Version { get;  set; }
    }
}
