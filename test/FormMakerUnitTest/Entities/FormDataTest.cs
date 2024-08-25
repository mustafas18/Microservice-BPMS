using FormMaker.Dtos;
using FormMaker.Entities;
using FormMaker.Enums;
using FormMakerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMakerUnitTest.Entities
{
    public class FormDataTest
    {
        public FormDataTest() { }

        [Fact]
        public void AddData() {
            //Arrange
            var componentData1 = new ComponentData
            {
                ComponentnId = 1,
                Value = new ComponentValue
                {
                    ComponentId = 1,
                    Label = "Name",
                    Value = "bob"
                }
            };
            var createFormDto = new CreateFormDataDto
            {
                AssigneeId = "8",
                FormId = 1,
                 ComponentDatas= new List<ComponentData>{
                    componentData1
                 }
            };
            var componentDatas = new List<ComponentData>{
                new ComponentData
                {
                     ComponentnId=1,
                        Value=new ComponentValue
                        {
                            ComponentId=2,
                            Label="OK",
                            Value="Hello" 
                        },

                },
                new ComponentData
                {
                     ComponentnId=2,
                        Value=new ComponentValue
                        {
                            ComponentId=2,
                            Label="Cancel",
                            Value="Bye"
                        },

                }
            };
            // Act
            var formData = new FormData(createFormDto);
            formData.RemoveComponents();
           
            _ = formData.AddRange(componentDatas);

            // Assert
            Assert.Equal(formData.ComponentDatas,componentDatas);
        }
    [Fact]
    public void RemoveData()
    {
        //Arrange
        var componentData1 = new ComponentData
        {
            ComponentnId = 1,
            Value = new ComponentValue
            {
                ComponentId = 1,
                Label = "Name",
                Value = "bob"
            }
        };
        var createFormDto = new CreateFormDataDto
        {
            AssigneeId = "8",
            FormId = 1,
            ComponentDatas = new List<ComponentData>{
                    componentData1
                 }
        };
        var componentDatas = new List<ComponentData>{
                new ComponentData
                {
                     ComponentnId=1,
                        Value=new ComponentValue
                        {
                            ComponentId=2,
                            Label="OK",
                            Value="Hello"
                        }
                }
            };
        // Act
        var formData = new FormData(createFormDto);
        formData.Remove(componentData1);
        // Assert
        Assert.Empty(formData.ComponentDatas);
    }
    }
}

