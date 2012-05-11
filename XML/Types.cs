using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace XML
{

    public struct Config
    {
        public int scr;
        public Notice notice;
        public List<DateSheet> datesheets;
    }

    public struct Notice
    {
        public string font;
        public Color color;
        public Color bgcolor;
        public int size;
        public bool bold;
        public int interval;
    }

    public struct DateSheet
    {
        public DateTime startDate;
        public DateTime endDate;
        public bool Mon, Tue, Wed, Thu, Fri, Sat, Sun;
        public List<TimeSheet> timesheets;
    }

    public struct TimeSheet
    {
        public DateTime startTime;
        public DateTime endTime;
        public PlayMode mode;
        public List<Content> contents;
    }

    public struct Content
    {
        public ContentType type;
        public string file;
        public int duration;
    }

    public enum PlayMode
    {
        sequencial = 0,
        random = 1
    }

    public enum ContentType
    {
        dir = 0,
        video = 1,
        powerpoint = 2
    }
}