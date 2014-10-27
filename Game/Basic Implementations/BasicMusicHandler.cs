using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;

namespace Game
{
    class BasicMusicHandler : SoundHandler
    {
        //Variables
        private Music music;

        //Interface Methods
        public BasicMusicHandler(String Filename) {
            music = new Music(Filename);
       } 
        public void Pause() { music.Pause(); }
        public void Play() { music.Play(); }
        public void SetPlayingOffset(System.TimeSpan Time) { music.PlayingOffset = Time; }
        public void Stop() { music.Stop(); }
        public void Loops(Boolean Loop) { music.Loop = Loop; }
        public void SetVolume(int Vol) { music.Volume = Vol; }
        public void SetPitch(float Pitch) { music.Pitch = Pitch; }
    }
}
