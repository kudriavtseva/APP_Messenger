using System;
using APP_Messenger.Models;

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

        string[] answers =
        {
            "I have to think",
            "Well...it's hard to say",
            "Why are you asking this question?",
            "Who knows...",
            "I'm not sure",
            "Let's change topic. I don't want to answer this question"
        };

        string[] questions =
        {
            "It's interesting, isn't it",
            "I see your point of view",
            "Do you really think so?",
            "Are you sure?",
            "I disagree with you",
            "I know a lot of people like you"
        };

        string[] silence = {
            "Why you wrote nothing?",
            "You should write something"
        };

        public Message Respond(Message ms, User user) {
            if (ms.Text == null) {
                return new Message(user, silence[r.Next(silence.Length)], BotName);
            } else {
                string[] next = ms.Text.Contains("?") ? answers : questions;
                return new Message(user, next[r.Next(next.Length)], BotName);
            }
        }
    }

}
