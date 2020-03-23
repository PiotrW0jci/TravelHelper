using System.Collections.Generic;
using System;

namespace TravelHelper.Core.Domain
{
    public class UserAchievement
    {
        public Guid Id {get; protected set;}
        public Guid UserId {get; protected set;}
        public DateTime  ObtainedAt{get; protected set;}
        public string AchievementName{get;protected set;}

        public IEnumerable<Achievement> Achievements {get;protected set;}
        
         protected UserAchievement()
        {
        }
    }
}