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
    public class FormTest
    {
        public FormTest() { }
        [Fact]
        public void CreateForm()
        {
            //Arrange
            var assignees = new List<string> { "1", "2" };
            var formComponents = new List<FormComponent> {new FormComponent(){
                Id=1,
                Type=ComponentTypeEnum.Button,
                Label="OK",
                Order=1,
                Readonly=false
               }
            };
            var formTmplate = new FormTemplate("Form1", formComponents, "as-dwds", 1, "sdf-asd-dw");

            //Act
            var form = new Form(1, 2, assignees, formTmplate, "sdf-asd-dw");

            //Assert
            Assert.NotNull(form);
        }
    }
}
