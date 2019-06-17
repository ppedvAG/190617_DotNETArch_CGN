using System;

namespace StrategiePattern_Demo
{
    class Auto
    {
        public Auto(IBremse bremse, IMotor motor, IAudioSystem audioSystem)
        {
            this.bremse = bremse ?? throw new ArgumentNullException(nameof(bremse));
            this.motor = motor ?? throw new ArgumentNullException(nameof(motor));
            this.audioSystem = audioSystem ?? throw new ArgumentNullException(nameof(audioSystem));
        }
        private readonly IBremse bremse;
        private readonly IMotor motor;
        private readonly IAudioSystem audioSystem;

        public int Geschwindigkeit { get; private set; }

        public void Beschleunigen()
        {
            Geschwindigkeit = motor.Beschleunigen(Geschwindigkeit);
        }
        public void Bremsen()
        {
            Geschwindigkeit = bremse.Bremsen(Geschwindigkeit);
        }

        public void MusikAbspielen() => audioSystem.SpieleMusikAb();
    }
}
