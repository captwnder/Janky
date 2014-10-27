using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;

namespace Game
{
    class BasicSoundHandler : SoundHandler
    {
        //Variables
        Sound sound;
        SoundBuffer soundBuffer;

        //Interface Functions
        public BasicSoundHandler(String Filename) {
            soundBuffer = new SoundBuffer(Filename);
            sound = new Sound(soundBuffer);
        }
        public void Pause() { sound.Pause(); }
        public void Play() { sound.Play(); }
        public void SetPlayingOffset(System.TimeSpan Time) { sound.PlayingOffset = Time; }
        public void Stop() { sound.Stop(); }
        public void Loops(Boolean Loop) { sound.Loop = Loop; }
        public void SetVolume(int Vol) { sound.Volume = Vol; }
        public void SetPitch(float Pitch) { sound.Pitch = Pitch; }
    }
}
