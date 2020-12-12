using System;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N3
{
    internal class Bloco : Retangulo
    {
        public Bloco(char rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir, BlocoType blocoType, string mode) : base(rotulo, paiRef, ptoInfEsq, ptoSupDir)
        {
            base.PontosAdicionar(ptoInfEsq);
            base.PontosAdicionar(new Ponto4D(ptoSupDir.X, ptoInfEsq.Y));
            base.PontosAdicionar(ptoSupDir);
            base.PontosAdicionar(new Ponto4D(ptoInfEsq.X, ptoSupDir.Y));
            BlocoType = blocoType;
            Mode = mode;

            switch (BlocoType)
            {
                case BlocoType.T:
                    this.GenerateT();
                    break;
                default:
                    break;
            }
        }

        public BlocoType BlocoType { get; set; }

        public string Mode { get; set; }

        public void GenerateT()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('L', this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('R', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
        }

        public void Rotate()
        {
            switch (BlocoType)
            {
                case BlocoType.T:
                    this.RotateT();
                    break;
                default:
                    break;
            }
        }

        public void RotateT()
        {
            foreach (var filho in this.GetFilhos())
            {
                switch (filho.rotulo)
                {
                    case 'L':
                        foreach (var pto in filho.pontosLista)
                        {
                            pto.X += 30;
                            pto.Y -= 30;
                        }
                        filho.rotulo = 'B';
                        break;
                    case 'B':
                        foreach (var pto in filho.pontosLista)
                        {
                            pto.X += 30;
                            pto.Y += 30;
                        }
                        filho.rotulo = 'R';
                        break;
                    case 'R':
                        foreach (var pto in filho.pontosLista)
                        {
                            pto.X -= 30;
                            pto.Y += 30;
                        }
                        filho.rotulo = 'T';
                        break;
                    case 'T':
                        foreach (var pto in filho.pontosLista)
                        {
                            pto.X -= 30;
                            pto.Y -= 30;
                        }
                        filho.rotulo = 'L';
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
