﻿#define CG_Gizmo
// #define CG_Privado

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;
using CG_N3;
using System.Linq;

namespace gcgcg
{
  class Mundo : GameWindow
  {
    private static Mundo instanciaMundo = null;

    private Mundo(int width, int height) : base(width, height) { }

    public static Mundo GetInstance(int width, int height)
    {
      if (instanciaMundo == null)
        instanciaMundo = new Mundo(width, height);
      return instanciaMundo;
    }

    private CameraOrtho camera = new CameraOrtho();
    public List<ObjetoGeometria> objetosLista = new List<ObjetoGeometria>();
    private Bloco objetoSelecionado = null;
    private char objetoId = '@';
    private bool bBoxDesenhar = false;
    private Bloco bloco;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = 0; camera.xmax = 300; camera.ymin = 0; camera.ymax = 300;

      Console.WriteLine(" --- Ajuda / Teclas: ");
      Console.WriteLine(" [  H     ] mostra teclas usadas. ");

      generateRandomBlocoType();

      GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
    }

    /// <summary>
    /// Gera um tipo aleatório de bloco
    /// </summary>
    protected void generateRandomBlocoType()
    {
        Array values = Enum.GetValues(typeof(BlocoType));
        Random random = new Random();
        BlocoType randomBar = (BlocoType)values.GetValue(random.Next(values.Length));
        objetoId = Utilitario.charProximo(objetoId);
        bloco = new Bloco(objetoId, null, new Ponto4D(120, 240, 0), new Ponto4D(150, 270, 0), randomBar);
        objetosLista.Add(bloco);
        objetoSelecionado = bloco;
        bloco = null;

     }

    protected void PutBlocoDown()
    {
        if(objetoSelecionado != null && !objetoSelecionado.Move(0, -30, camera, objetosLista) )
        {
            if (objetoSelecionado.pontosLista[0].X == 120 && objetoSelecionado.pontosLista[0].Y == 240)
            {
                objetoSelecionado = null;
                return;
            }
            VerifyLineFull();
            this.generateRandomBlocoType();
        }
    }

    protected void VerifyLineFull()
        {
            var lineScan = 210;

            while (lineScan > 0)
            {
                var lineCount = 0;

                foreach (var objeto in objetosLista)
                {
                    if (objeto.pontosLista.Count() > 0)
                    {
                        if (objeto.pontosLista[2].Y == lineScan && objeto.pontosLista[0].Y == (lineScan - 30))
                        {
                            lineCount++;
                        }

                    }
                    foreach (var objetoFilho in objeto.GetFilhos())
                    {
                        if (objetoFilho.pontosLista.Count() > 0)
                        {
                            if (objetoFilho.pontosLista[2].Y == lineScan && objetoFilho.pontosLista[0].Y == (lineScan - 30))
                            {
                                lineCount++;
                            }

                        }

                    }
                }

                if (lineCount == 10)
                {

                    foreach (var objeto in objetosLista)
                    {
                        if (objeto.pontosLista.Count() > 0)
                        {
                            if (objeto.pontosLista[2].Y == lineScan && objeto.pontosLista[0].Y == (lineScan - 30))
                            {
                                objeto.PontosRemoverTodos();
                            }

                        }


                        foreach (var objetoFilho in objeto.GetFilhos())
                        {
                            if (objetoFilho.pontosLista.Count() > 0)
                            {
                                if (objetoFilho.pontosLista[2].Y == lineScan && objetoFilho.pontosLista[0].Y == (lineScan - 30))
                                {
                                    objetoFilho.PontosRemoverTodos();
                                }

                            }
                        }
                    }


                    foreach (var objeto in objetosLista)
                    {
                        if (objeto.pontosLista.Count() > 0)
                        {
                            if (objeto.pontosLista[2].Y > lineScan && objeto.pontosLista[0].Y > (lineScan - 30))
                            {
                                foreach (var pto in objeto.pontosLista)
                                {
                                    pto.Y -= 30;
                                }
                            }
                        }


                        foreach (var objetoFilho in objeto.GetFilhos())
                        {
                            if (objetoFilho.pontosLista.Count() > 0)
                            {
                                if (objetoFilho.pontosLista[2].Y > lineScan && objetoFilho.pontosLista[0].Y > (lineScan - 30))
                                {
                                    foreach (var pto in objetoFilho.pontosLista)
                                    {
                                        pto.Y -= 30;
                                    }
                                }

                            }

                        }
                    }


                }

                lineScan -= 30;

            }
        }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
      PutBlocoDown();
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();
      for (var i = 0; i < objetosLista.Count; i++)
        objetosLista[i].Desenhar();
      if (bBoxDesenhar && (objetoSelecionado != null))
        objetoSelecionado.BBox.Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      else if (objetoSelecionado != null)
      {
        if (e.Key == Key.Left)
            objetoSelecionado.Move(-30, 0, camera, objetosLista);
        else if (e.Key == Key.Right)
            objetoSelecionado.Move(30, 0, camera, objetosLista);
        else if (e.Key == Key.Down)
            objetoSelecionado.Move(0, -30, camera, objetosLista);
        else if (e.Key == Key.Space)
        {
            objetoSelecionado.Rotate(camera);
        }
        else
            Console.WriteLine(" __ Tecla não implementada.");
      }
      else
        Console.WriteLine(" __ Tecla não implementada.");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG_N3";
      window.Run(1.0 / 1.0);
    }
  }
}
