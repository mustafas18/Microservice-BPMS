using eShop.Identity.API.Models;
using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class CreateFormDto
    {
        public int BpmId { get; set; }
        public int NodeId { get; set; }
        public List<string> Assignees { get; set; }
        public int TemplateId { get; set; }
    }
}
