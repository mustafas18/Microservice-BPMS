using FormMaker.Entities;
using FormMaker.Enums;
using FormMakerApi.Dtos;
using FormMakerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMakerUnitTest.Entities
{
    public class FormTemplateTest
    {
        public FormTemplateTest() { }
        [Fact]
        public void Update_FormTemplate()
        {
            // Arrange
            var formComponents = new List<FormComponent> {new FormComponent(){
                Id=1,
                Type=ComponentTypeEnum.Button,
                Label="OK",
                Order=1,
                Readonly=false
               }
            };
            var formTmplate = new FormTemplate("Form1", formComponents, "as-dwds", 1, "sdf-asd-dw");
            var newTemplate = new UpdateFormTemplateDto
            {
                Title = "Form (Edited)",
                Components = formTmplate.Components
            };


            // Act
            formTmplate.Update(newTemplate);


            // Assert
            Assert.Equal("Form (Edited)",formTmplate.Title);
            Assert.Equal(formComponents,formTmplate.Components);
        }
    }
}
