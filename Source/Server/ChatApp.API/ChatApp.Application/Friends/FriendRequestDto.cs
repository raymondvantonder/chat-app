using AutoMapper;
using ChatApp.Application.Common.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Friends
{
    public class FriendRequestDto : IMapFrom<FriendRequestEntity>
    {
        public long RequestId { get; set; }
        public string Name { get; set; }
        public DateTime RequestedTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FriendRequestEntity, FriendRequestDto>()
                .ForMember(d => d.RequestId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.User.Name))
                .ForMember(d => d.RequestedTime, opt => opt.MapFrom(s => s.CreatedTime));
        }
    }
}
