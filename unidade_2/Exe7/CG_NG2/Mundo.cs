#define CG_Gizmo

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;

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
    protected List<Objeto> objetosLista = new List<Objeto>();
    private Circulo circuloMenor;
    private Circulo circuloMaior;
    private Retangulo obj_Retangulo;
    private double circuloMaiorRaio;
    private bool circuloMenorEstaForaCirculoMaior = false;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = -400; camera.xmax = 400; camera.ymin = -400; camera.ymax = 400;

      circuloMaior = new Circulo("D", null, 72, 100, new Ponto4D(150,150));
      circuloMaior.ObjetoCor.CorR = 0; circuloMaior.ObjetoCor.CorG = 0; circuloMaior.ObjetoCor.CorB = 0;

      circuloMaiorRaio = Math.Pow(circuloMaior.Raio, 2);

      circuloMenor = new Circulo("D", null, 72, 40, new Ponto4D(150,150));
      circuloMenor.ObjetoCor.CorR = 0; circuloMenor.ObjetoCor.CorG = 0; circuloMenor.ObjetoCor.CorB = 0;

      obj_Retangulo = new Retangulo("A", null, Matematica.GerarPtosCirculo(45, 100) + new Ponto4D(150,150), Matematica.GerarPtosCirculo(225, 100) + new Ponto4D(150,150));
      obj_Retangulo.ObjetoCor.CorR = 255; obj_Retangulo.ObjetoCor.CorG = 0; obj_Retangulo.ObjetoCor.CorB = 255;

      GL.ClearColor(0.5f,0.5f,0.5f,1.0f);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadIdentity();
#if CG_Gizmo
      Sru3D();
#endif
      circuloMaior.Desenhar();
      obj_Retangulo.Desenhar();
      circuloMenor.Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      else if (e.Key == Key.C)
      {
        MoverCirculoMenor(0,1);
      }
      else if (e.Key == Key.B)
      {
        MoverCirculoMenor(0,-1);
      }
      else if (e.Key == Key.D)
      {
        MoverCirculoMenor(1,0);
      }
      else if (e.Key == Key.E)
      {
        MoverCirculoMenor(-1,0);
      }
      else
        Console.WriteLine(" __ Tecla não implementada.");
    }

    public void MoverCirculoMenor(double x = 0, double y = 0) {

      if (circuloMenorEstaForaCirculoMaior)
      {
        circuloMenor.PontoCentro.X = 150;
        circuloMenor.PontoCentro.Y = 150;
        obj_Retangulo.ObjetoCor.CorR = 255; obj_Retangulo.ObjetoCor.CorG = 0; obj_Retangulo.ObjetoCor.CorB = 255;
        circuloMenorEstaForaCirculoMaior = false;
      }
      else if (circuloMenor.PontoCentro.X > obj_Retangulo.ListaPontos()[1].X &&
          circuloMenor.PontoCentro.X < obj_Retangulo.ListaPontos()[3].X &&
          circuloMenor.PontoCentro.Y > obj_Retangulo.ListaPontos()[3].Y &&
          circuloMenor.PontoCentro.Y < obj_Retangulo.ListaPontos()[1].Y)
      {
        circuloMenor.PontoCentro.X += x;
        circuloMenor.PontoCentro.Y += y;
        obj_Retangulo.ObjetoCor.CorR = 255; obj_Retangulo.ObjetoCor.CorG = 0; obj_Retangulo.ObjetoCor.CorB = 255;
      }
      else
      {
        circuloMenorEstaForaCirculoMaior = Matematica.DistanciaEntrePontos(circuloMenor.PontoCentro, circuloMaior.PontoCentro) > (double)circuloMaiorRaio;

        if ((circuloMenor.PontoCentro.X < obj_Retangulo.ListaPontos()[1].X ||
          circuloMenor.PontoCentro.X > obj_Retangulo.ListaPontos()[3].X ||
          circuloMenor.PontoCentro.Y < obj_Retangulo.ListaPontos()[3].Y ||
          circuloMenor.PontoCentro.Y > obj_Retangulo.ListaPontos()[1].Y) &&
          !circuloMenorEstaForaCirculoMaior)
        {
          circuloMenor.PontoCentro.X += x;
          circuloMenor.PontoCentro.Y += y;
          obj_Retangulo.ObjetoCor.CorR = 255; obj_Retangulo.ObjetoCor.CorG = 255; obj_Retangulo.ObjetoCor.CorB = 0;
        }

        if (circuloMenorEstaForaCirculoMaior)
        {
          obj_Retangulo.ObjetoCor.CorR = 0; obj_Retangulo.ObjetoCor.CorG = 255; obj_Retangulo.ObjetoCor.CorB = 255;
        }
      }
    }

#if CG_Gizmo
    private void Sru3D()
    {
      GL.LineWidth(3);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3((byte)255,(byte)0,(byte)0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3((byte)0,(byte)255,(byte)0);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.Color3((byte)0,(byte)0,(byte)255);
      GL.End();
    }
#endif
  }
  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = Mundo.GetInstance(600, 600);
      window.Title = "CG_N2";
      window.Run(1.0 / 60.0);
    }
  }
}
