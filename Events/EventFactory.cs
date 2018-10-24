using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    class EventFactory
    {

        public EventFactory()
        {

        }
        public Event EventFactoryModule(string id,string type)
        {
            switch (type)
            {
                case "tweet":
                    return new Tweet(id);
                case "facebook-status-update":
                    return new Facebook(id);
                case "photo": 
                     return new Photo(id);
                case "video":
                    return new Video(id);
                case "tracklog":
                    return new Tracklog(id);
                case "friendmeeting":
                    return new MetFriend(id);
                default:
                    break;
            }

            return null;
        }

        public EventDataHandler EventDataHandlerFactory(Event @event)
        {
            switch(@event.GetType().Name)
            {
                case nameof(Facebook): return new FacebookDataHandler();
                case nameof(Photo): return new PhotoDataHandler();
                case nameof(Tracklog): return new TracklogDataHandler();
                case nameof(Tweet): return new TweetDataHandler();
                case nameof(Video): return new VideoDataHandler();
                case nameof(MetFriend): return new MetFriendDataHandler();
            }

            return null;
        }

    }
}
