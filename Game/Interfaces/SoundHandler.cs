using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface SoundHandler
    {
        void Pause();
        void Play();
        void SetPlayingOffset(System.TimeSpan Time);
        void Stop();
        void Loops(Boolean loops);
        void SetVolume(int Vol);
        void SetPitch(float Pitch);
    }
}
