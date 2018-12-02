using System;
using APP_Messenger.Models;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.Managers;

namespace APP_Messenger.Managers
{
    internal class PhatiqueDialogManager
    {
        internal const string BotName = "bot";
        private Random r = new Random();
        private string _answer;

        public string Answer
        {
            get => _answer;
            set => _answer = value;
        }

        readonly string[] answers =
        {
            "I have to think",
            "Well...it's hard to say",
            "Why are you asking this question?",
            "Who knows...",
            "I'm not sure",
            "Let's change topic. I don't want to answer this question"
        };

        readonly string[] questions =
        {
            "It's interesting, isn't it",
            "I see your point of view",
            "Do you really think so?",
            "Are you sure?",
            "I disagree with you",
            "I know a lot of people like you"
        };

        readonly string[] silence = {
            "Why you wrote nothing?",
            "You should write something"
        };

        public MessageUIModel StartConversation(User user) {
            return new MessageUIModel(new Message(user, BotName+": Hello. How are you?", BotName));
        }

        public MessageUIModel Respond(MessageUIModel ms, User user) {
            if (ms.Text == null) {
                var responce = new Message(user, silence[r.Next(silence.Length)], BotName);
                DBManager.AddMessage(responce);
                var responceUI = new MessageUIModel(responce);
                return responceUI;
            }
            else {
                string[] next = ms.Text.Contains("?") ? answers : questions;
                var responce = new Message(user, next[r.Next(next.Length)], BotName);
                DBManager.AddMessage(responce);
                var responceUI = new MessageUIModel(responce);
                return responceUI;
            }
        }
    }

}
