using Assignment1.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.View
{
    class EventGuiData
    {

        //This class could be replaced by a factory object that returns an object with all gui descriptive information
        public Bitmap GetMarkerIcon(Event @event)
        {
            switch (@event.GetType().Name)
            {
                case nameof(Facebook): return Properties.Resources._001_facebook;
                case nameof(Tweet): return Properties.Resources._005_twitter;
                case nameof(MetFriend): return Properties.Resources._003_friendship;
                case nameof(Photo): return Properties.Resources._002_photo_camera;
                case nameof(Tracklog): return Properties.Resources._004_route;
                case nameof(Video): return Properties.Resources._001_video_player;
            }
            return null;
        }

        public string FriendlyName(Event @event)
        {
            switch (@event.GetType().Name)
            {
                case nameof(Facebook): return "Facebook Post";
                case nameof(Tweet): return "Tweet";
                case nameof(MetFriend): return "Your Friend";
                case nameof(Photo): return "Photo";
                case nameof(Tracklog): return "Tracklog";
                case nameof(Video): return "Video";
            }
            return "";
        }

    }
}
