using FormMaker.Dtos;
using FormMaker.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FormMakerApi.Entities
{
    public class FormData:BaseEntity
    {
        public FormData()
        {
                
        }
        public FormData(CreateFormDataDto model)
        {
            FormId=model.FormId;
            FormTemplateId=model.FormTemplateId;
            AssigneeId=model.AssigneeId;
            DoneDate=model.DoneDate;
            ComponentDatas = model.ComponentDatas;
        }
   
        public int FormId { get;private set; }
        public int FormTemplateId { get; private set; }
        public string AssigneeId { get; private set; }
        [JsonInclude]
        public List<ComponentData> ComponentDatas { get; private set; }
        public DateTime AssignedTime { get; private set; }=DateTime.Now;
        public DateTime? DoneDate { get; private set; }
        
        public List<ComponentData> AddRange(List<ComponentData> data)
        {
            ComponentDatas.AddRange(data);
            return ComponentDatas;
        }
        public void Remove(ComponentData data)
        {
            ComponentDatas.Remove(data);
        }
        public bool RemoveComponents()
        {
            ComponentDatas.Clear();
            return ComponentDatas.Any();
        }
    }

    public class ComponentData
    {
        public int ComponentnId { get; set; }
        public ComponentValue Value { get; set; }
    }



}
