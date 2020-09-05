using AutoMapper;
using ChatApp.Application.Common.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Friends
{
    public class FriendDto : IMapFrom<UserEntity>, IMapFrom<FriendEntity>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FriendEntity, FriendDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Friend.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Friend.Email))
                .ForMember(d => d.Nickname, opt => opt.MapFrom(s => s.Friend.Nickname))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.Friend.DateOfBirth))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Friend.Name));
        }
    }
}
