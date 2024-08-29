using AutoMapper;
using Bpms.Api.Profiles;
using BPMS.Domain.Dtos;
using BPMS.Domain.Entities;
using BpmsDomain.Entities;

namespace BpmsUnitTest.Enitities
{
    public class WorkflowTemplateTest
    {
        private static IMapper _mapper;
        public WorkflowTemplateTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new NodeProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void UpdateNode_Should_UpdateNode()
        {
            // Arrange
            var workflowTemplate = new WorkflowTemplate();
            workflowTemplate.AddNode(_mapper.Map<NodeDto, Node>(new NodeDto
            {
                Title = "node1",
                Description = "this is node1",
                Height = 100,
                Width = 100,
                Id = 1,
                NodeType = BpmsApi.Enums.NodeTypeEnum.StartEvent,
                PositionX = 0,
                PositionY = 0,
                WorkflowId = 1,

            }));
            var node = new Node();
            node= _mapper.Map<NodeDto, Node>(new NodeDto
            {
                Title = "node1",
                Description = "this the second version of node1",
                Height = 100,
                Width = 100,
                Id = 1,
                NodeType = BpmsApi.Enums.NodeTypeEnum.StartEvent,
                PositionX = 32,
                PositionY = 12,
                WorkflowId = 1,

            });

            // Act
            workflowTemplate.UpdateNode(node);

            // Assert
            Assert.Equal(node,workflowTemplate.Nodes.FirstOrDefault());
        }
    }
}