﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYSICS
{
    public class VBody
    {
        public List<Rope> ropeList;
        public List<Personaje> perso;
        public List<Personaje> estre;
        public List<Estrellas> estrella;
        public List<Personaje> spikeballs;
        public List<Sombrero> hat;
        public List<Caja> caja;    
        public VBody() {

            ropeList = new List<Rope>();
            perso= new List<Personaje>();
            estre= new List<Personaje>();
            estrella = new List<Estrellas>();
            spikeballs = new List<Personaje>();
            hat = new List<Sombrero>();
            caja = new List<Caja>();
        }

    }
}
