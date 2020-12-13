using System;
using System.Collections.Generic;
using System.Linq;
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
        public Bloco(char rotulo, Objeto paiRef, Ponto4D ptoInfEsq, Ponto4D ptoSupDir, BlocoType blocoType) : base(rotulo, paiRef, ptoInfEsq, ptoSupDir, blocoType)
        {
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
        public new BlocoType BlocoType { get; }

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
            this.FilhoAdicionar(new Retangulo('L', this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('R', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco I
        /// </summary>
        private void GenerateI()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 60), new Ponto4D(pto.X + 30, pto.Y - 30), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco Z
        /// </summary>
        private void GenerateZ()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X - 30, pto.Y), new Ponto4D(pto.X, pto.Y + 30), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X - 30, pto.Y - 30), new Ponto4D(pto.X, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco L
        /// </summary>
        private void GenerateL()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X + 30, pto.Y - 30), new Ponto4D(pto.X + 60, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco J
        /// </summary>
        private void GenerateJ()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X, pto.Y + 30), new Ponto4D(pto.X + 30, pto.Y + 60), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X - 30, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco S
        /// </summary>
        private void GenerateS()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X - 30, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Gera o bloco O
        /// </summary>
        private void GenerateO()
        {
            Ponto4D pto = pontosLista[0];
            this.FilhoAdicionar(new Retangulo('A', this, new Ponto4D(pto.X + 30, pto.Y), new Ponto4D(pto.X + 60, pto.Y + 30), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('B', this, new Ponto4D(pto.X + 30, pto.Y - 30), new Ponto4D(pto.X + 60, pto.Y), this.BlocoType));
            this.FilhoAdicionar(new Retangulo('C', this, new Ponto4D(pto.X, pto.Y - 30), new Ponto4D(pto.X + 30, pto.Y), this.BlocoType));
        }

        /// <summary>
        /// Move um objeto
        /// </summary>
        /// <param name="x">Deslocamento em X</param>
        /// <param name="y">Deslocamento em Y</param>
        public void Move(double x, double y, CameraOrtho camera)
        {
            if(this.validMovement(x,y,camera))
            {
                // Percorre os pontos do quadro principal
                foreach (var pto in pontosLista)
                {
                    pto.X += x;
                    pto.Y += y;
                }

                // Percorre os filhos do objeto principal
                foreach (var filho in this.GetFilhos())
                {
                    foreach (var pto in filho.pontosLista)
                    {
                        pto.X += x;
                        pto.Y += y;
                    }
                }
            }
        }

        /// <summary>
        /// Função que define qual rotação será feita com base no tipo de bloco
        /// </summary>
        public void Rotate(CameraOrtho camera)
        {
            switch (BlocoType)
            {
                case BlocoType.T:
                    this.RotateT(camera);
                    break;
                case BlocoType.I:
                    this.RotateI(camera);
                    break;
                case BlocoType.Z:
                    this.RotateZ(camera);
                    break;
                case BlocoType.L:
                    this.RotateL(camera);
                    break;
                case BlocoType.J:
                    this.RotateJ(camera);
                    break;
                case BlocoType.S:
                    this.RotateS(camera);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Valida se a rotação está dentro dos limites da câmera
        /// </summary>
        /// <param name="pto">Pontos da rotação</param>
        /// <param name="camera">Câmera</param>
        /// <returns>true se é valida, false se não é</returns>
        private bool IsRotationValid(Ponto4D pto, CameraOrtho camera)
        {
            if (pto.X > camera.xmax || pto.X < camera.xmin || pto.Y > camera.ymax || pto.Y < camera.ymin)
                return false;
            return true;
        }

        /// <summary>
        /// Restaura valores originais dos filhos
        /// </summary>
        /// <param name="filhosPontosBackup">Rotulos dos filhos</param>
        /// <param name="filhosRotuloBackup">Pontos dos filhos</param>
        private void RestoreFilhos(List<List<Ponto4D>> filhosPontosBackup, List<char> filhosRotuloBackup)
        {
            int i = 0;
            foreach (var filho in this.GetFilhos())
            {
                filho.rotulo = filhosRotuloBackup[i];
                filho.pontosLista = filhosPontosBackup[i];
                i++;
            }
        }

        /// <summary>
        /// Rotação do objeto T
        /// </summary>
        private void RotateT(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            foreach (var filho in this.GetFilhos())
            {
                int j = 0;
                switch (filho.rotulo)
                {
                    case 'L':
                        foreach (var pto in filho.pontosLista)
                        {
                            filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                            j++;
                            pto.X += 30;
                            pto.Y -= 30;
                            if (!IsRotationValid(pto, camera))
                            {
                                RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                return;
                            }            
                        }
                        filho.rotulo = 'B';
                        break;
                    case 'B':
                        foreach (var pto in filho.pontosLista)
                        {
                            filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                            j++;
                            pto.X += 30;
                            pto.Y += 30;
                            if (!IsRotationValid(pto, camera))
                            {
                                RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                return;
                            }
                        }
                        filho.rotulo = 'R';
                        break;
                    case 'R':
                        foreach (var pto in filho.pontosLista)
                        {
                            filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                            j++;
                            pto.X -= 30;
                            pto.Y += 30;
                            if (!IsRotationValid(pto, camera))
                            {
                                RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                return;
                            }
                        }
                        filho.rotulo = 'T';
                        break;
                    case 'T':
                        foreach (var pto in filho.pontosLista)
                        {
                            filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                            j++;
                            pto.X -= 30;
                            pto.Y -= 30;
                            if (!IsRotationValid(pto, camera))
                            {
                                RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                return;
                            }
                        }
                        filho.rotulo = 'L';
                        break;
                    default:
                        break;
                }
                i++;
            }
        }

        /// <summary>
        /// Rotação do objeto I
        /// </summary>
        private void RotateI(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())  
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X += 30;
                                    pto.Y += 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X += 60;
                                    pto.Y += 60;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X += 30;
                                    pto.Y += 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X -= 30;
                                    pto.Y -= 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X -= 60;
                                    pto.Y -= 60;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
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
        private void RotateZ(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.Y += 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X += 60;
                                    pto.Y += 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.Y -= 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;
                                    pto.X -= 60;
                                    pto.Y -= 30;
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
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
        private void RotateL(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y += 60;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos 
                                    pto.X -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode3";
                    break;
                case "Mode3":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode4";
                    break;
                case "Mode4":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
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
        private void RotateJ(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode3";
                    break;
                case "Mode3":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode4";
                    break;
                case "Mode4":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.Y -= 60;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
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
        private void RotateS(CameraOrtho camera)
        {
            var filhosRotuloBackup = this.GetFilhos().Select(filho => filho.rotulo).ToList();
            var filhosPontosBackup = this.GetFilhos().Select(filho => new List<Ponto4D>(filho.pontosLista)).ToList();
            int i = 0;
            switch (this.Mode)
            {
                case "Mode1":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y += 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 60;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode2";
                    break;
                case "Mode2":
                    foreach (var filho in this.GetFilhos())
                    {
                        int j = 0;
                        switch (filho.rotulo)
                        {
                            case 'A':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X += 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'B':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 30;
                                    pto.Y -= 30;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            case 'C':
                                foreach (var pto in filho.pontosLista)
                                {
                                    // Faz o backup dos pontos atuais
                                    filhosPontosBackup[i][j] = new Ponto4D(pto.X, pto.Y);
                                    j++;

                                    // Modifica os pontos
                                    pto.X -= 60;

                                    // Valida modificação
                                    if (!IsRotationValid(pto, camera))
                                    {
                                        RestoreFilhos(filhosPontosBackup, filhosRotuloBackup);
                                        return;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    this.Mode = "Mode1";
                    break;
                default:
                    break;
            }
        }

        private bool validMovement(double x, double y, CameraOrtho camera)
        {
            foreach(var pto in pontosLista)
            {
                if (pto.X + x > camera.xmax  || pto.X + x < camera.xmin || pto.Y + y > camera.ymax || pto.Y + y < camera.ymin)
                {
                    return false;
                }
            }

            foreach (var filho in this.GetFilhos())
            {
                foreach (var pto in filho.pontosLista)
                {
                    if (pto.X + x > camera.xmax || pto.X + x < camera.xmin || pto.Y + y > camera.ymax || pto.Y + y < camera.ymin)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
