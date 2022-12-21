using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static little_bits_drive_me_crazy.Particle;

namespace little_bits_drive_me_crazy
{
    public abstract class IImpactPoint
    {
        public float X; 
        public float Y;
        public Color Color;
        public float Prikol;

        
        public abstract void ImpactParticle(Particle particle);

        
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;


        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }
    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;


        public override void ImpactParticle(Particle particle)
        {

            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); 
            if (r + particle.Radius < Power / 2 + particle.Radius * 2)
            {
                
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX = 0;
                particle.SpeedY = 0;
                particle.SpeedX -= gX * (Power + 200) / r2;
                particle.SpeedY -= gY * (Power + 200) / r2;
            }   
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }
    public class EnterPort : IImpactPoint
    {
        public int Power = 100;
        public float X2, Y2;
        

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Power / 2)
            {
                particle.X += X2 - this.X;
                particle.Y += Y2 - this.Y;

            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Blue),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
            g.DrawEllipse(
                   new Pen(Color.Orange),
                   X2 - Power / 2,
                   Y2 - Power / 2,
                   Power,
                   Power
               );

        }
    }

    public class OutPoint : IImpactPoint
    {
        public int Power = 100;
        

        public override void ImpactParticle(Particle particle)
        {
        }
        
        public void CreateNewParticle(Particle particle)
        {
            
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Orange),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }

    public class PrintPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            
            float gX = X - particle.X;
            float gY = Y - particle.Y;
           

            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Power / 2)
            {
                
                if (particle is ParticleColorful)
                {
                    
                    var p = (particle as ParticleColorful);
                    p.FromColor = Color;
                    p.ToColor = Color;
                    
                    
                }
                
            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }
}
