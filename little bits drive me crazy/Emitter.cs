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

        public void UpdateState()
        {
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
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    var particle = new ParticleColorful();
                    particle.FromColor = Color.White;
                    particle.ToColor = Color.FromArgb(0, Color.Black);

                    ResetParticle(particle);

                    /*
                    var particle = new ParticleColorful();

                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    */
                    particles.Add(particle);
                    
                }
                else
                {
                    break;
                }
            }
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
            particle.Life = 20 + Particle.rnd.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rnd.Next(360);
            var speed = 1 + Particle.rnd.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rnd.Next(10);
        }
    }
}
