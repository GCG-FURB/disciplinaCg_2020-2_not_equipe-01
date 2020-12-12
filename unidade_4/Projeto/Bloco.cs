﻿using System;
using CG_Biblioteca;
using gcgcg;
using OpenTK.Graphics.OpenGL;

namespace CG_N3
{
    internal class Bloco : Retangulo
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="rotulo">Rótulo do bloco</param>
        /// <param name="paiRef">Referência pai</param>
        /// <param name="ptoInfEsq">Ponto inferior esquerdo</param>
        /// <param name="ptoSupDir">Ponto superior direito</param>
        /// <param name="blocoType">Tipo de bloco</param>
        public Bloco(char rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir, BlocoType blocoType) : base(rotulo, paiRef, ptoInfEsq, ptoSupDir)
        {
            base.PontosAdicionar(ptoInfEsq);
            base.PontosAdicionar(new Ponto4D(ptoSupDir.X, ptoInfEsq.Y));
            base.PontosAdicionar(ptoSupDir);
            base.PontosAdicionar(new Ponto4D(ptoInfEsq.X, ptoSupDir.Y));
            BlocoType = blocoType;
            Mode = "Mode1";

            // Gera o bloco de acordo com o parâmetro
            switch (BlocoType)
            {
                case BlocoType.T:
                    this.GenerateT();
                    break;
                case BlocoType.I:
                    this.GenerateI();
                    break;
                case BlocoType.Z:
                    this.GenerateZ();
                    break;
                case BlocoType.L:
                    this.GenerateL();
                    break;
                case BlocoType.J:
                    this.GenerateJ();
                    break;
                case BlocoType.S:
                    this.GenerateS();
                    break;
                case BlocoType.O:
                    this.GenerateO();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Tipo do bloco gerado
        /// </summary>
        public BlocoType BlocoType { get; }

        /// <summary>
        /// Modo de rotação do bloco
        /// </summary>
        internal string Mode { get; set; }

        /// <summary>
        /// Gera o bloco T
        /// </summary>
        private void GenerateT()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('L', this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('R', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
        }

        /// <summary>
        /// Gera o bloco I
        /// </summary>
        private void GenerateI()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 60), new Ponto4D(pto.X + 30, pto.Y - 30)));
        }

        /// <summary>
        /// Gera o bloco Z
        /// </summary>
        private void GenerateZ()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X - 30, pto.Y - 30), new Ponto4D(pto.X, pto.Y)));
        }

        /// <summary>
        /// Gera o bloco L
        /// </summary>
        private void GenerateL()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X + 30, pto.Y - 30), new Ponto4D(pto.X + 60, pto.Y)));
        }

        /// <summary>
        /// Gera o bloco J
        /// </summary>
        private void GenerateJ()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X - 30, pto.Y)));
        }

        /// <summary>
        /// Gera o bloco S
        /// </summary>
        private void GenerateS()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X - 30, pto.Y)));
        }

        /// <summary>
        /// Gera o bloco O
        /// </summary>
        private void GenerateO()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30)));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X + 30, pto.Y - 30), new Ponto4D(pto.X + 60, pto.Y)));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y)));
        }

        /// <summary>
        /// Função que define qual rotação será feita com base no tipo de bloco
        /// </summary>
        public void Rotate()
        {
            switch (BlocoType)
            {
                case BlocoType.T:
                    this.RotateT();
                    break;
                case BlocoType.I:
                    this.RotateI();
                    break;
                case BlocoType.Z:
                    this.RotateZ();
                    break;
                case BlocoType.L:
                    this.RotateL();
                    break;
                case BlocoType.J:
                    this.RotateJ();
                    break;
                case BlocoType.S:
                    this.RotateS();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotação do objeto T
        /// </summary>
        private void RotateT()
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

        /// <summary>
        /// Rotação do objeto I
        /// </summary>
        private void RotateI()
        {
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 60;
                                    pto.Y += 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 60;
                                    pto.Y -= 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotação do objeto Z
        /// </summary>
        private void RotateZ()
        {
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 60;
                                    pto.Y += 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 60;
                                    pto.Y -= 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotação do objeto L
        /// </summary>
        private void RotateL()
        {
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y += 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode3";
                    break;
                case "Mode3":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y -= 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode4";
                    break;
                case "Mode4":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y -= 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotação do objeto J
        /// </summary>
        private void RotateJ()
        {
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y += 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode3";
                    break;
                case "Mode3":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode4";
                    break;
                case "Mode4":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.Y -= 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rotação do objeto S
        /// </summary>
        private void RotateS()
        {
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y += 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X += 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    pto.X -= 60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }
    }
}
