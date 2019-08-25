using AutoMapper;

namespace NotSteam.Core.Infrastructure.AutoMapper.Interfaces
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
