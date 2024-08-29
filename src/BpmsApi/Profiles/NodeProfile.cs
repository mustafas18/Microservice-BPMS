using AutoMapper;
using BPMS.Domain.Dtos;
using BPMS.Domain.Entities;

namespace Bpms.Api.Profiles
{
    public class NodeProfile:Profile
    {
        public NodeProfile()
        {
            CreateMap<NodeDto, Node>();
        }
    }
}
