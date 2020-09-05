using AutoMapper;
using ChatApp.Application.Chats.Queries;
using ChatApp.Application.Common.Mappings;
using ChatApp.Application.Users.Queries;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApp.Application.Chats
{
    public class ChatVm : IMapFrom<ChatEntity>
    {
        public ChatDto Chat { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<MessagesDto> Messages { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChatParticipantEntity, UserDto>()
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.User.DateOfBirth))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.User.Name))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.User.Password))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.User.Id));

            profile.CreateMap<ChatEntity, ChatVm>()
                .ForMember(d => d.Messages, opt => opt.MapFrom(s => s.Messages))
                .ForMember(d => d.Chat, opt => opt.MapFrom(s => s))
                .ForMember(d => d.Users, opt => opt.MapFrom(s => s.ChatParticipants));
        }
    }
}
