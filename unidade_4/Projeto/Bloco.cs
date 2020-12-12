using System;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N3
{
    internal class Bloco : Retangulo
    {
        public Bloco(char rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir) : base(rotulo, paiRef, ptoInfEsq, ptoSupDir)
        {
            base.PontosAdicionar(ptoInfEsq);
            base.PontosAdicionar(new Ponto4D(ptoSupDir.X, ptoInfEsq.Y));
            base.PontosAdicionar(ptoSupDir);
            base.PontosAdicionar(new Ponto4D(ptoInfEsq.X, ptoSupDir.Y));
        }

        public void GenerateT()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Bloco(this.rotulo, this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30)));
            this.FilhoAdicionar(new Bloco(this.rotulo, this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30)));
            this.FilhoAdicionar(new Bloco(this.rotulo, this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
        }
    }
}
