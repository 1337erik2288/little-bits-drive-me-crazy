﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace little_bits_drive_me_crazy
{
    public class Particle
    {
        public int Radius;
        public float X;
        public float Y;
        public float Direction; //направление движения в пучину безысходности...
        public float Speed; //скорость движения туда же
        public static Random rnd = new Random();
        
        public Particle()
        {
            Direction = rnd.Next(360);
            Speed = 1 + rnd.Next(10);
            Radius = 2 + rnd.Next(10);
        }

    }
}