﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class MessageLog
    {
        public string Time { get; set; }

        public long Id { get; set; }

        public string Msg { get; set; }

        public string FirstName { get; set; }

        public MessageLog(
            string Time, 
            string Msg, 
            string FirstName, 
            long Id)
        {
            this.Time = Time;
            this.Msg = Msg;
            this.FirstName = FirstName;
            this.Id = Id;
        }
/*
        public DateTime Time;

        public long ChatId;

        public string FirstName;

        public string Msg;

        public string MsgType;

        public MessageLog(
            DateTime Time,
            long ChatId, 
            string FirstName, 
            string Msg, 
            string MsgType
            )
        {
            this.Time = Time;
            this.ChatId = ChatId;
            this.FirstName = FirstName;
            this.Msg = Msg;
            this.MsgType = MsgType;
        }*/
    }
}
