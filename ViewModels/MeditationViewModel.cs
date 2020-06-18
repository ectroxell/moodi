using moodi.Models;

namespace moodi.ViewModels
{
    public class MeditationViewModel
    {
        public MeditationViewModel(Mood mood, Meditation meditation)
        {
            Mood = mood;
            Meditation = meditation;
        }

        public Mood Mood { get; set; }
        public Meditation Meditation { get; set; }
    }
}