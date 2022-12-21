using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace little_bits_drive_me_crazy
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0; //Гравитации нет! Австралия - вымысел! Камни - зло! Скупайте фантики!!!
        public int ParticlesCount = 500;
        public int X; 
        public int Y;  
        public int Direction = 0; 
        public int Spreading = 360; 
        public int SpeedMin = 1; 
        public int SpeedMax = 10; 
        public int RadiusMin = 2; 
        public int RadiusMax = 10; 
        public int LifeMin = 20; 
        public int LifeMax = 100;
        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White; 
        public Color ColorTo = Color.FromArgb(0, Color.Black);
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    
                    ResetParticle(particle);
                    /* particle.Life = 20 + Particle.rnd.Next(100);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    var direction = (double)Particle.rnd.Next(360);
                    var speed = 1 + Particle.rnd.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                    ;
                    particle.Radius = 2 + Particle.rnd.Next(10);
                    */
                    if (particlesToCreate > 0)
                    {
                        
                        particlesToCreate -= 1; 
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
            /*
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);

                    ResetParticle(particle);

                    //*
                    var particle = new ParticleColorful();

                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    //
                    particles.Add(particle);
                    
                }
                else
                {
                    break;
                }
            }
            */
            
        }
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            if (particle is ParticleColorful)// Mеням цвет обратно на исходный
            {
                var p = (particle as ParticleColorful);
                (particle as ParticleColorful).FromColor = ColorFrom;
                p.ToColor = ColorTo;
            }
            particle.Life = Particle.rnd.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;


            var direction = Direction
                + (double)Particle.rnd.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rnd.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rnd.Next(RadiusMin, RadiusMax);
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
    }
}
