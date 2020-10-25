#define CG_Gizmo
// #define CG_Privado

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
    private ObjetoGeometria objetoSelecionado = null;
    private CameraOrtho camera = new CameraOrtho();
    private List<Ponto4D> pontosControle = new List<Ponto4D>();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private Ponto4D pontoAtual = null;
    private Spline spline = null;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      camera.xmin = -400; camera.xmax = 400; camera.ymin = -400; camera.ymax = 400;

      pontosControle.Add(new Ponto4D(100, -100));
      pontosControle.Add(new Ponto4D(100, 100));
      pontosControle.Add(new Ponto4D(-100, 100));
      pontosControle.Add(new Ponto4D(-100, -100));

      pontoAtual = pontosControle[0];

      spline = new Spline("S", null, pontosControle, 10);
      objetoSelecionado = spline;
      objetosLista.Add(spline);

      SegReta segReta1 = new SegReta("1", null, pontosControle[0], pontosControle[1]);
      SegReta segReta2 = new SegReta("2", null, pontosControle[1], pontosControle[2]);
      SegReta segReta3 = new SegReta("3", null, pontosControle[2], pontosControle[3]);

      segReta1.ObjetoCor.CorR = 0; segReta1.ObjetoCor.CorG = 255; segReta1.ObjetoCor.CorB = 255;
      segReta2.ObjetoCor.CorR = 0; segReta2.ObjetoCor.CorG = 255; segReta2.ObjetoCor.CorB = 255;
      segReta3.ObjetoCor.CorR = 0; segReta3.ObjetoCor.CorG = 255; segReta3.ObjetoCor.CorB = 255;

      objetosLista.Add(segReta1);
      objetosLista.Add(segReta2);
      objetosLista.Add(segReta3);

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
      DesenharPontosControle();

      for (var i = 0; i < objetosLista.Count; i++)
        objetosLista[i].Desenhar();
      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        Exit();
      }
      else if (e.Key == Key.Number1 || e.Key == Key.Keypad1)
      {
        pontoAtual = pontosControle[0];
      }
      else if (e.Key == Key.Number2 || e.Key == Key.Keypad2)
      {
        pontoAtual = pontosControle[1];
      }
      else if (e.Key == Key.Number3 || e.Key == Key.Keypad3)
      {
        pontoAtual = pontosControle[2];
      }
      else if (e.Key == Key.Number4 || e.Key == Key.Keypad4)
      {
        pontoAtual = pontosControle[3];
      }
      else if (e.Key == Key.C) // cima
      {
        pontoAtual.Y ++;
      }
      else if (e.Key == Key.B) // baixo
      {
        pontoAtual.Y --;
      }
      else if (e.Key == Key.E) // esquerda
      {
        pontoAtual.X --;
      }
      else if (e.Key == Key.D) //direita
      {
        pontoAtual.X ++;
      }
      else if (e.Key == Key.Plus || e.Key == Key.KeypadPlus)
      {
        spline.QuantidadePontos++;
      }
      else if (e.Key == Key.Minus || e.Key == Key.KeypadMinus)
      {
        spline.QuantidadePontos--;
      }
      else if (e.Key == Key.R)
      {
        ResetPontosControle();
      }
      else
      {
        Console.WriteLine(" __ Tecla não implementada.");
      }
    }

    private void DesenharPontosControle() {
      GL.PointSize(5);
      GL.Begin(PrimitiveType.Points);

      foreach (Ponto4D ponto in pontosControle)
      {
        if (ponto == pontoAtual) {
          GL.Color3((byte)255,(byte)0,(byte)0);
        } else {
          GL.Color3((byte)0,(byte)0,(byte)0);
        }

        GL.Vertex2(ponto.X, ponto.Y);
      }

      GL.End();
    }

    private void ResetPontosControle() {
      pontosControle[0].X = 100;
      pontosControle[0].Y = -100;
      pontosControle[1].X = 100;
      pontosControle[1].Y = 100;
      pontosControle[2].X = -100;
      pontosControle[2].Y = 100;
      pontosControle[3].X = -100;
      pontosControle[3].Y = -100;
    }

#if CG_Gizmo
    private void Sru3D()
    {
      GL.LineWidth(1);
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
