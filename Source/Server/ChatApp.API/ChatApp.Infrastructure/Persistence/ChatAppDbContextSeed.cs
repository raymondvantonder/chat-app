using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Persistence
{
    public static class ChatAppDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ChatAppDbContext context)
        {
            UserEntity user1 = NewMethod("1");
            UserEntity user2 = NewMethod("2");
            UserEntity user3 = NewMethod("3");
            UserEntity user4 = NewMethod("4");

            if (!context.Users.Any())
            {

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.Users.Add(user4);

                await context.SaveChangesAsync();

                context.Chats.Add(new ChatEntity
                {
                    CreatorId = user1.Id,
                    Name = Guid.NewGuid().ToString(),
                    ChatParticipants = new List<ChatParticipantEntity>
                    {
                        new ChatParticipantEntity
                        {
                            User = user1
                        },
                        new ChatParticipantEntity
                        {
                            User = user2
                        },
                    },
                    Messages = new List<MessageEntity>
                    {
                        new MessageEntity
                        {
                            Message = "Hi",
                            Sender = user1
                        },
                        new MessageEntity
                        {
                            Message = "Hello",
                            Sender = user2
                        },
                        new MessageEntity
                        {
                            Message = "How are you?",
                            Sender = user1
                        },
                    }
                });
                user1.Friends.Add(new FriendEntity { FriendId = 2, UserId = 1 });
                user1.Friends.Add(new FriendEntity { FriendId = 3, UserId = 1 });

                user4.FriendRequests.Add(new FriendRequestEntity { RequestedUserId = 1 });

                await context.SaveChangesAsync();
            }
        }

        private static UserEntity NewMethod(string suffix)
        {
            return new UserEntity
            {
                Name = $"Testing{suffix}",
                Email = $"Test{suffix}@gmail.com",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Nickname = $"Test {suffix}",
                Password = "test"
            };
        }
    }
}
