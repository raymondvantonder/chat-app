using AutoMapper;
using ChatApp.Application.Common.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Chats
{
    public class MessagesDto : IMapFrom<MessageEntity>
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
        public long SenderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MessageEntity, MessagesDto>()
                .ForMember(d => d.SendTime, opt => opt.MapFrom(s => s.CreatedTime));
        }
    }
}
