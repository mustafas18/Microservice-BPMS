using FormMaker.Entities;
using FormMakerApi.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;

namespace FormMakerApi.Entities
{
    public class FormTemplate : BaseEntity
    {
        public FormTemplate()
        {

        }
        public FormTemplate(string title,
                            List<FormComponent> components,
                            string userId,
                            int version,
                            string tenantId) : base(tenantId)
        {
            Title = title;
            Components = components;
            CreatorId = userId;
            Version = version;
        }
        public string Title { get; private set; }

        public List<FormComponent> Components { get; private set; }
        public string CreatorId { get; private set; }
        public int Version { get; private set; }

        public FormTemplate Update(UpdateFormTemplateDto model)
        {
            Title = model.Title;
            Components = model.Components;
            //TODO: Get user from identity service
          //  Creator = ;
            Version = 1;
           return this;
        }
    }

 
}
