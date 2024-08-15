using eShop.Identity.API.Models;
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
                            ApplicationUser applicationUser,
                            int version)
        {
            Title = title;
            Components = components;
            Creator = applicationUser;
            Version = version;
        }
        public string Title { get; private set; }

        public List<FormComponent> Components { get; private set; }
        public ApplicationUser Creator { get; private set; }
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
    public class FormComponent
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Label { get; private set; }
        public List<ComponentValue>? Values { get; set; }
        public ComponentValue? InputValue { get; set; }
        public int Order { get; private set; }
        public bool Readonly { get; private set; }
        public string? Tooltip { get; private set; }
    }
 
}
